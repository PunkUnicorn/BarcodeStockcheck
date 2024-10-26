using Microsoft.VisualBasic.Devices;
using System.Media;

namespace BarcodeStocktake
{
    public partial class Form1 : Form
    {
        private BarcodeLookupService barcodeLookupService;
        private BarcodeLookupService goUpsService2;
        private BarcodeLookupService? useService;
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
            useService = barcodeLookupService;

            comboBoxMatchValue.Enabled = checkBoxToMatchValue.Checked;

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

            if (useService is null)
                useService = checkBoxSwapProvider.Checked ? barcodeLookupService : goUpsService2;

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
            checkBoxSwapProvider.Checked = true;
            textBoxAlias.BackColor = backColor;
            textBoxBarcode.BackColor = backColor;
            labelError.Text = "";
            textBoxQuantity.Text = DefaultQuantity.ToString();
            textBoxBarcode.Clear();
            textBoxAlias.Clear();
            textBoxBarcode.Focus();
        }

        private void checkBoxSwapProvider_CheckedChanged(object sender, EventArgs e)
        {
            var me = (CheckBox)sender;
            useService = me.Checked ? barcodeLookupService : goUpsService2;
            textBoxBarcode.Focus();
        }

        private void comboBoxSearchByOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var me = (ComboBox)sender;

            if (checkBoxToMatchValue.Checked)
            {
                comboBoxMatchValue.Text = null;
                comboBoxMatchValue.Items.Clear();
                comboBoxMatchValue.Items.AddRange(_auditRecords.GetPropertyValues(checkBoxInventoryIncludeBlank.Checked, me.Text));
            }
        }

        private void checkBoxToMatchValue_CheckedChanged(object sender, EventArgs e)
        {
            var me = (CheckBox)sender;
            comboBoxMatchValue.Enabled = me.Checked;

            if (checkBoxToMatchValue.Checked)
            {
                comboBoxMatchValue.Text = null;
                comboBoxMatchValue.Items.Clear();
                comboBoxMatchValue.Items.AddRange(_auditRecords.GetPropertyValues(checkBoxInventoryIncludeBlank.Checked, comboBoxSearchByOptions.Text));
            }
        }

        private void buttonRefreshList_Click(object sender, EventArgs e)
        {
            listViewInventory.Columns.Clear();
            listViewInventory.Items.Clear();
            listViewInventory.Clear();

            if (checkBoxToMatchValue.Checked && !string.IsNullOrWhiteSpace(comboBoxMatchValue.Text))
            {

                var widths = new int[] { 100, 100, 250, 100, 150, 100 };
                var getWidth = (int i) => i >= widths.Length ? widths.Last() : widths[i];
                int i = 0;
                foreach (var prop in typeof(AuditItem).GetProperties())
                    listViewInventory.Columns.Add(prop.Name, getWidth(i++));

                var items = _auditRecords.GetStocklist()
                    .Where(w => w.GetType().GetProperties().Single(s => s.Name == comboBoxSearchByOptions.Text).GetValue(w)?.ToString()?.Equals(comboBoxMatchValue.Text, StringComparison.OrdinalIgnoreCase) ?? false)
                    .ToList();

                foreach (var item in items)
                {
                    var data = typeof(AuditItem).GetProperties()
                        .Select(s => s.GetValue(item)?.ToString() ?? "")
                        .ToArray();

                    listViewInventory.Items.Insert(0, new ListViewItem(data));
                }

                //var widths = new int[] { 150, 100 };
                //var getWidth = (int i) => i >= widths.Length ? widths.Last() : widths[i];
                //int i = 0;
                //foreach (var prop in new[] { comboBoxSearchByOptions.Text, "Count" })
                //    listViewInventory.Columns.Add(prop, getWidth(i++));

                //var items = _auditRecords.GetStocklist()
                //    .Where(w => w.GetType().GetProperties().Single(s => s.Name == comboBoxSearchByOptions.Text).GetValue(w)?.ToString() == comboBoxMatchValue.Text)
                //    .GroupBy(gb => gb.GetType().GetProperties().Single(s => s.Name == comboBoxSearchByOptions.Text).Name)
                //    .ToDictionary(k=>k.Key, v=>v.ToList());

                //foreach (var key in items.Keys)
                //    listViewInventory.Items.Insert(0, new ListViewItem(new string[] { key, items[key].Count().ToString() }));
            }
            else
            {
                var widths = new int[] { 100, 100, 250, 100, 150, 100 };
                var getWidth = (int i) => i >= widths.Length ? widths.Last() : widths[i];
                int i = 0;
                foreach (var prop in typeof(AuditItem).GetProperties())
                    listViewInventory.Columns.Add(prop.Name, getWidth(i++));

                var items = _auditRecords.GetStocklist()
                    //.Where(w => w.GetType().GetProperties().Single(s => s.Name == comboBoxSearchByOptions.Text).GetValue(w)?.ToString()?.Equals(comboBoxMatchValue.Text, StringComparison.OrdinalIgnoreCase) ?? false)
                    .ToList();

                foreach (var item in items)
                { 
                    var data = typeof(AuditItem).GetProperties()
                        .Select(s => s.GetValue(item)?.ToString() ?? "")
                        .ToArray();

                    listViewInventory.Items.Insert(0, new ListViewItem(data));
                }
            }
        }
    }
}
