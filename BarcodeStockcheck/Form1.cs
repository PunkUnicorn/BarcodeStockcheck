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
        private AuditRecords AuditRecords = new AuditRecords();
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


            var widths = new int[] {100, 100, 250, 100, 150 };
            var getWidth = (int i) => i >= widths.Length ? widths.Last() : widths[i];
            int i=0;
            foreach (var prop in typeof(AuditLog).GetProperties())
                listView1.Columns.Add(prop.Name, getWidth(i++));
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
                    var logItem = AuditRecords.UpdateItem(updateItem);
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

            listView1.Items.Insert(0, new ListViewItem(data));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetDataEntry();
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
    }
}
