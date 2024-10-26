namespace BarcodeStocktake
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textBoxBarcode = new TextBox();
            buttonLookup = new Button();
            pictureBoxCover = new PictureBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            textBoxStorageCode = new TextBox();
            textBoxAlias = new TextBox();
            textBoxQuantity = new TextBox();
            label1 = new Label();
            textBoxTitle = new TextBox();
            panel2 = new Panel();
            textBoxDescription = new TextBox();
            buttonCopyDescription = new Button();
            panel3 = new Panel();
            button1 = new Button();
            textBoxDetails = new TextBox();
            labelError = new Label();
            checkBoxSwapProvider = new CheckBox();
            splitContainer1 = new SplitContainer();
            listView1 = new ListView();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCover).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxBarcode
            // 
            textBoxBarcode.Location = new Point(3, 3);
            textBoxBarcode.Name = "textBoxBarcode";
            textBoxBarcode.PlaceholderText = "Barcode";
            textBoxBarcode.Size = new Size(176, 23);
            textBoxBarcode.TabIndex = 0;
            // 
            // buttonLookup
            // 
            buttonLookup.Location = new Point(185, 3);
            buttonLookup.Name = "buttonLookup";
            buttonLookup.Size = new Size(75, 23);
            buttonLookup.TabIndex = 99;
            buttonLookup.TabStop = false;
            buttonLookup.Text = "Go";
            buttonLookup.UseVisualStyleBackColor = false;
            buttonLookup.Click += buttonLookup_Click;
            // 
            // pictureBoxCover
            // 
            pictureBoxCover.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBoxCover.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxCover.Location = new Point(3, 38);
            pictureBoxCover.Name = "pictureBoxCover";
            pictureBoxCover.Size = new Size(242, 210);
            pictureBoxCover.TabIndex = 2;
            pictureBoxCover.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(textBoxBarcode);
            flowLayoutPanel1.Controls.Add(buttonLookup);
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Controls.Add(textBoxTitle);
            flowLayoutPanel1.Controls.Add(pictureBoxCover);
            flowLayoutPanel1.Controls.Add(panel2);
            flowLayoutPanel1.Controls.Add(panel3);
            flowLayoutPanel1.Controls.Add(labelError);
            flowLayoutPanel1.Controls.Add(checkBoxSwapProvider);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(773, 299);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(textBoxStorageCode);
            panel1.Controls.Add(textBoxAlias);
            panel1.Controls.Add(textBoxQuantity);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(266, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(285, 29);
            panel1.TabIndex = 100;
            // 
            // textBoxStorageCode
            // 
            textBoxStorageCode.Location = new Point(182, 3);
            textBoxStorageCode.Name = "textBoxStorageCode";
            textBoxStorageCode.PlaceholderText = "Storage Code";
            textBoxStorageCode.Size = new Size(100, 23);
            textBoxStorageCode.TabIndex = 3;
            textBoxStorageCode.TabStop = false;
            // 
            // textBoxAlias
            // 
            textBoxAlias.Location = new Point(95, 3);
            textBoxAlias.Name = "textBoxAlias";
            textBoxAlias.PlaceholderText = "Alias";
            textBoxAlias.Size = new Size(81, 23);
            textBoxAlias.TabIndex = 2;
            textBoxAlias.TabStop = false;
            // 
            // textBoxQuantity
            // 
            textBoxQuantity.Location = new Point(62, 3);
            textBoxQuantity.Name = "textBoxQuantity";
            textBoxQuantity.Size = new Size(27, 23);
            textBoxQuantity.TabIndex = 1;
            textBoxQuantity.Text = "1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 6);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 0;
            label1.Text = "&Quantity:";
            // 
            // textBoxTitle
            // 
            textBoxTitle.Location = new Point(557, 3);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.ReadOnly = true;
            textBoxTitle.Size = new Size(179, 23);
            textBoxTitle.TabIndex = 3;
            textBoxTitle.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(textBoxDescription);
            panel2.Controls.Add(buttonCopyDescription);
            panel2.Location = new Point(251, 38);
            panel2.Name = "panel2";
            panel2.Size = new Size(264, 210);
            panel2.TabIndex = 102;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxDescription.Location = new Point(3, 3);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.PlaceholderText = "No description";
            textBoxDescription.ReadOnly = true;
            textBoxDescription.Size = new Size(258, 173);
            textBoxDescription.TabIndex = 4;
            textBoxDescription.TabStop = false;
            // 
            // buttonCopyDescription
            // 
            buttonCopyDescription.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonCopyDescription.AutoSize = true;
            buttonCopyDescription.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonCopyDescription.Location = new Point(3, 182);
            buttonCopyDescription.Name = "buttonCopyDescription";
            buttonCopyDescription.Size = new Size(108, 25);
            buttonCopyDescription.TabIndex = 101;
            buttonCopyDescription.TabStop = false;
            buttonCopyDescription.Text = "Copy &Description";
            buttonCopyDescription.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(button1);
            panel3.Controls.Add(textBoxDetails);
            panel3.Location = new Point(521, 38);
            panel3.Name = "panel3";
            panel3.Size = new Size(242, 210);
            panel3.TabIndex = 103;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.AutoSize = true;
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.Location = new Point(3, 182);
            button1.Name = "button1";
            button1.Size = new Size(83, 25);
            button1.TabIndex = 102;
            button1.TabStop = false;
            button1.Text = "Copy De&tails";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBoxDetails
            // 
            textBoxDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxDetails.Location = new Point(3, 3);
            textBoxDetails.Multiline = true;
            textBoxDetails.Name = "textBoxDetails";
            textBoxDetails.PlaceholderText = "No details";
            textBoxDetails.ReadOnly = true;
            textBoxDetails.Size = new Size(236, 173);
            textBoxDetails.TabIndex = 6;
            textBoxDetails.TabStop = false;
            // 
            // labelError
            // 
            labelError.AutoSize = true;
            labelError.BackColor = SystemColors.Info;
            labelError.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelError.ForeColor = SystemColors.InfoText;
            labelError.Location = new Point(769, 35);
            labelError.Name = "labelError";
            labelError.Size = new Size(0, 30);
            labelError.TabIndex = 104;
            // 
            // checkBoxSwapProvider
            // 
            checkBoxSwapProvider.AutoSize = true;
            checkBoxSwapProvider.Checked = true;
            checkBoxSwapProvider.CheckState = CheckState.Checked;
            checkBoxSwapProvider.Location = new Point(3, 254);
            checkBoxSwapProvider.Name = "checkBoxSwapProvider";
            checkBoxSwapProvider.Size = new Size(357, 19);
            checkBoxSwapProvider.TabIndex = 105;
            checkBoxSwapProvider.TabStop = false;
            checkBoxSwapProvider.Text = "BarcodeLookup primary, Go-upc secondary (uncheck to &Swap)";
            checkBoxSwapProvider.UseVisualStyleBackColor = true;
            checkBoxSwapProvider.CheckedChanged += checkBoxSwapProvider_CheckedChanged;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(listView1);
            splitContainer1.Size = new Size(773, 924);
            splitContainer1.SplitterDistance = 299;
            splitContainer1.TabIndex = 4;
            splitContainer1.TabStop = false;
            // 
            // listView1
            // 
            listView1.Dock = DockStyle.Fill;
            listView1.Location = new Point(0, 0);
            listView1.Name = "listView1";
            listView1.Size = new Size(773, 621);
            listView1.TabIndex = 0;
            listView1.TabStop = false;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // Form1
            // 
            AcceptButton = buttonLookup;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(773, 924);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Barcode Stocktake";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxCover).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBoxBarcode;
        private Button buttonLookup;
        private PictureBox pictureBoxCover;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private Label label1;
        private SplitContainer splitContainer1;
        private TextBox textBoxQuantity;
        private TextBox textBoxTitle;
        private TextBox textBoxDescription;
        private TextBox textBoxDetails;
        private Panel panel2;
        private Button buttonCopyDescription;
        private Panel panel3;
        private Button button1;
        private ListView listView1;
        private Label labelError;
        private TextBox textBoxAlias;
        private CheckBox checkBoxSwapProvider;
        private TextBox textBoxStorageCode;
    }
}
