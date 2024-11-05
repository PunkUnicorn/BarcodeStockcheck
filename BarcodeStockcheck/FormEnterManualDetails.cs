using BarcodeStocktake;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeStockcheck
{
    public partial class FormEnterManualDetails : Form
    {
        public FormEnterManualDetails()
        {
            InitializeComponent();
        }

        private void buttonAddOk_Click(object sender, EventArgs e)
        {
            Tag = new BarcodeLookupResult
            {
                SourceUrl = null,
                LookupTimestamp = DateTime.Now,
                Code = textBoxAddBarcode.Text,
                CodeType = "",
                Publisher = textBoxAddPublisher.Text,
                Title = textBoxAddTitle.Text,
                Description = textBoxAddDescription.Text,
                ImageUrl = textBoxAddImageUrl.Text
            };
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormEnterManualDetails_Load(object sender, EventArgs e)
        {
            textBoxAddBarcode.Text = (string) Tag;
        }
    }
}
