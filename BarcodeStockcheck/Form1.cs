using Microsoft.VisualBasic.Devices;
using System.Linq;
using System.Media;

namespace BarcodeStocktake
{
    public partial class Form1 : Form
    {
        private BarcodeLookupService barcodeLookupService;
        private BarcodeLookupService goUpsService2;
        //private BarcodeLookupService? useService;
        private IStoreBarcodeLookupResults _storeLookupResults = new StoreLookupResults();
        private AuditRecords _auditRecords = new AuditRecords();
        private Color backColor;

        // how to add listview details
        // https://stackoverflow.com/questions/7146567/winforms-listview-not-showing-items-in-detailsview
        private const int DefaultQuantity = 1;

        public Form1()
        {
            InitializeComponent();

            backColor = textBoxBarcode.BackColor;
            barcodeLookupService = new BarcodeLookupService(new BarcodeExecuteBarcodeLookup(_storeLookupResults));
            goUpsService2 = new BarcodeLookupService(new BarcodeExecuteGoUpc(_storeLookupResults));
            //useService = barcodeLookupService;

            //comboBoxMatchValue.Enabled = checkBoxToMatchValue.Checked;

            var widths = new int[] { 100, 100, 250, 100, 150, 100 };
            var getWidth = (int i) => i >= widths.Length ? widths.Last() : widths[i];
            int i = 0;
            foreach (var prop in typeof(AuditLog).GetProperties())
                listViewLog.Columns.Add(prop.Name, getWidth(i++));

            //i = 0;
            //foreach (var prop in typeof(AuditItem).GetProperties())
            //    listViewInventory.Columns.Add(prop.Name, getWidth(i++));

        }

        private async void buttonLookup_Click(object sender, EventArgs e)
        {
            var me = (Button)sender;

            var useService = radioButtonBarcodeLookup.Checked ? barcodeLookupService : goUpsService2;

            var code = textBoxBarcode.Text;
            var alias = code != textBoxAlias.Text ? textBoxAlias.Text : "";
            var quantityToAdd = int.Parse(textBoxQuantity.Text);
            var location = textBoxStorageCode.Text;

            var info = await useService.GetBarcodeInfoAsync(code, alias);

            var auditItemToUpdate = new AuditItem(_storeLookupResults, code, location);

            ResetDataEntry();

            if (info is null)
            {
                SystemSounds.Hand.Play();
                labelError.Text = useService.Error;
                textBoxAlias.BackColor = Color.Red;
                textBoxBarcode.BackColor = Color.Red;
                textBoxAlias.Text = code;
                textBoxBarcode.Text = code;
            }
            else
            {
                bool updateFailed = true;
                try
                {
                    var updateItem = new AuditRecords.UpdateItemDetails(auditItemToUpdate, location, quantityToAdd);
                    var logItem = _auditRecords.UpdateItem(updateItem);
                    updateFailed = false;
                    AddToVisualList(logItem!);
                }
                catch (Exception ex)
                {
                    if (updateFailed)
                    {
                        SystemSounds.Hand.Play();
                        labelError.Text = "Uppdate failed! " + ex.Message;
                    }
                    else
                    {
                        labelError.Text = "Display failed to update (but details were saved) " + ex.Message;
                    }
                }
            }
        }

        private void AddToVisualList(AuditLog auditLogItem)
        {
            var data = typeof(AuditLog).GetProperties()
                .Select(s => s.GetValue(auditLogItem).ToString())
                .ToArray();

            listViewLog.Items.Insert(0, new ListViewItem(data));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetDataEntry();

            comboBoxSearchByOptions.Items.AddRange(_auditRecords.GetSearchByOptions());
        }

        private void ResetDataEntry()
        {
            textBoxAlias.BackColor = backColor;
            textBoxBarcode.BackColor = backColor;
            labelError.Text = "";
            textBoxQuantity.Text = DefaultQuantity.ToString();
            textBoxBarcode.Clear();
            textBoxAlias.Clear();
            textBoxBarcode.Focus();
        }

        //private void checkBoxSwapProvider_CheckedChanged(object sender, EventArgs e)
        //{
        //    var me = (CheckBox)sender;
        //    useService = me.Checked ? barcodeLookupService : goUpsService2;
        //    textBoxBarcode.Focus();
        //}

        private void comboBoxSearchByOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var me = (ComboBox)sender;

            comboBoxMatchValue.Text = null;
            comboBoxMatchValue.Items.Clear();
            try { comboBoxMatchValue.Items.AddRange(_auditRecords.GetPropertyValues(checkBoxInventoryIncludeBlank.Checked, me.Text)); }
            catch { }
        }

        private void checkBoxToMatchValue_CheckedChanged(object sender, EventArgs e)
        {
            var me = (CheckBox)sender;
            comboBoxMatchValue.Enabled = me.Checked;

            comboBoxMatchValue.Text = null;
            comboBoxMatchValue.Items.Clear();
            try { comboBoxMatchValue.Items.AddRange(_auditRecords.GetPropertyValues(checkBoxInventoryIncludeBlank.Checked, comboBoxSearchByOptions.Text)); }
            catch { }
        }

        private void buttonRefreshList_Click(object sender, EventArgs e)
        {
            labelInventoryQuantityTotal.Text = "";
            listViewInventory.Columns.Clear();
            listViewInventory.Items.Clear();
            listViewInventory.Clear();

            var widths = new int[] { 27, 95, 60, 100, 200, 50, 150 };
            var getWidth = (int i) => i >= widths.Length ? widths.Last() : widths[i];
            int i = 0;
            foreach (var prop in typeof(AuditItem).GetProperties())
                listViewInventory.Columns.Add(prop.Name, getWidth(i++));

            var items = _auditRecords.GetStocklist();

            if (!string.IsNullOrWhiteSpace(comboBoxMatchValue.Text))
            {
                var matchValue = new MatchValue(comboBoxSearchByOptions.Text, comboBoxMatchValue.Text);
                var narrowItems = items.Where(matchValue.WhereMatchesValue);

                if (checkBoxInventoryIncludeBlank.Checked)
                    narrowItems = narrowItems.Concat(items.Where(matchValue.WhereMatchesBlank));

                items = narrowItems.ToList();
            }

            var totalQuantity = 0;
            foreach (var item in items)
            {
                var data = typeof(AuditItem).GetProperties()
                    .Select(s => s.GetValue(item)?.ToString() ?? "")
                    .ToArray();

                totalQuantity += typeof(AuditItem).GetProperties()
                    .Where(prop => prop.Name.Equals("quantity", StringComparison.OrdinalIgnoreCase))
                    .Select(s => int.Parse(s.GetValue(item)?.ToString() ?? "0"))
                    .Sum();

                listViewInventory.Items.Insert(0, new ListViewItem(data));
            }
            labelInventoryQuantityTotal.Text = $"Shown quantity: {totalQuantity}";
        }

        private class MatchValue
        {
            private readonly string _matchPropertyName;
            private readonly string _matchValue;

            public MatchValue(string matchPropertyName, string matchValue) { _matchPropertyName = matchPropertyName; _matchValue = matchValue; }
            public bool WhereMatchesValue(AuditItem item)
            {
                return item.GetType()
                        .GetProperties()
                        .Single(s => s.Name == _matchPropertyName)
                        .GetValue(item)
                        ?.ToString()
                        ?.Equals(_matchValue, StringComparison.OrdinalIgnoreCase) ?? false;
            }

            public bool WhereMatchesBlank(AuditItem item)
            {
                return string.IsNullOrWhiteSpace(item.GetType()
                            .GetProperties()
                            .Single(s => s.Name == _matchPropertyName)
                            .GetValue(item)
                            ?.ToString());
            }

            public bool WhereMatchesValueOrMatchesBlank(AuditItem item)
            {
                return WhereMatchesValue(item) || WhereMatchesBlank(item);
            }
        }
    }
}
