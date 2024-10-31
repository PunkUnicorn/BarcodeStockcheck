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
            buttonCopyDescription = new Button();
            textBoxDescription = new TextBox();
            panel3 = new Panel();
            button1 = new Button();
            textBoxDetails = new TextBox();
            labelError = new Label();
            panel5 = new Panel();
            radioButtonGoUpc = new RadioButton();
            radioButtonBarcodeLookup = new RadioButton();
            splitContainer1 = new SplitContainer();
            tabControl1 = new TabControl();
            tabPageAuditLog = new TabPage();
            listViewLog = new ListView();
            tabPageInventory = new TabPage();
            listViewInventory = new ListView();
            flowLayoutPanel2 = new FlowLayoutPanel();
            panel4 = new Panel();
            label3 = new Label();
            labelInventoryQuantityTotal = new Label();
            buttonRefreshList = new Button();
            checkBoxInventoryIncludeBlank = new CheckBox();
            comboBoxMatchValue = new ComboBox();
            comboBoxSearchByOptions = new ComboBox();
            label2 = new Label();
            buttonAddManually = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCover).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageAuditLog.SuspendLayout();
            tabPageInventory.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            panel4.SuspendLayout();
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
            pictureBoxCover.Location = new Point(3, 254);
            pictureBoxCover.Name = "pictureBoxCover";
            pictureBoxCover.Size = new Size(242, 210);
            pictureBoxCover.TabIndex = 2;
            pictureBoxCover.TabStop = false;
            pictureBoxCover.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(textBoxBarcode);
            flowLayoutPanel1.Controls.Add(buttonLookup);
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Controls.Add(textBoxTitle);
            flowLayoutPanel1.Controls.Add(panel2);
            flowLayoutPanel1.Controls.Add(panel3);
            flowLayoutPanel1.Controls.Add(labelError);
            flowLayoutPanel1.Controls.Add(panel5);
            flowLayoutPanel1.Controls.Add(buttonAddManually);
            flowLayoutPanel1.Controls.Add(pictureBoxCover);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(839, 106);
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
            textBoxTitle.PlaceholderText = "Title";
            textBoxTitle.ReadOnly = true;
            textBoxTitle.Size = new Size(179, 23);
            textBoxTitle.TabIndex = 3;
            textBoxTitle.TabStop = false;
            textBoxTitle.Visible = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(buttonCopyDescription);
            panel2.Controls.Add(textBoxDescription);
            panel2.Location = new Point(3, 38);
            panel2.Name = "panel2";
            panel2.Size = new Size(264, 210);
            panel2.TabIndex = 102;
            panel2.Visible = false;
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
            // panel3
            // 
            panel3.Controls.Add(button1);
            panel3.Controls.Add(textBoxDetails);
            panel3.Location = new Point(273, 38);
            panel3.Name = "panel3";
            panel3.Size = new Size(242, 210);
            panel3.TabIndex = 103;
            panel3.Visible = false;
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
            labelError.Location = new Point(521, 35);
            labelError.Name = "labelError";
            labelError.Size = new Size(0, 30);
            labelError.TabIndex = 104;
            // 
            // panel5
            // 
            panel5.Controls.Add(radioButtonGoUpc);
            panel5.Controls.Add(radioButtonBarcodeLookup);
            panel5.Location = new Point(527, 38);
            panel5.Name = "panel5";
            panel5.Size = new Size(162, 51);
            panel5.TabIndex = 106;
            // 
            // radioButtonGoUpc
            // 
            radioButtonGoUpc.AutoSize = true;
            radioButtonGoUpc.Location = new Point(3, 28);
            radioButtonGoUpc.Name = "radioButtonGoUpc";
            radioButtonGoUpc.Size = new Size(113, 19);
            radioButtonGoUpc.TabIndex = 1;
            radioButtonGoUpc.Text = "Use go-upc.com";
            radioButtonGoUpc.UseVisualStyleBackColor = true;
            // 
            // radioButtonBarcodeLookup
            // 
            radioButtonBarcodeLookup.AutoSize = true;
            radioButtonBarcodeLookup.Checked = true;
            radioButtonBarcodeLookup.Location = new Point(3, 3);
            radioButtonBarcodeLookup.Name = "radioButtonBarcodeLookup";
            radioButtonBarcodeLookup.Size = new Size(157, 19);
            radioButtonBarcodeLookup.TabIndex = 0;
            radioButtonBarcodeLookup.TabStop = true;
            radioButtonBarcodeLookup.Text = "Use BarcodeLookup.com";
            radioButtonBarcodeLookup.UseVisualStyleBackColor = true;
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
            splitContainer1.Panel2.Controls.Add(tabControl1);
            splitContainer1.Size = new Size(839, 866);
            splitContainer1.SplitterDistance = 106;
            splitContainer1.TabIndex = 4;
            splitContainer1.TabStop = false;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageAuditLog);
            tabControl1.Controls.Add(tabPageInventory);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(839, 756);
            tabControl1.TabIndex = 1;
            tabControl1.TabStop = false;
            // 
            // tabPageAuditLog
            // 
            tabPageAuditLog.Controls.Add(listViewLog);
            tabPageAuditLog.Location = new Point(4, 24);
            tabPageAuditLog.Name = "tabPageAuditLog";
            tabPageAuditLog.Padding = new Padding(3);
            tabPageAuditLog.Size = new Size(831, 728);
            tabPageAuditLog.TabIndex = 0;
            tabPageAuditLog.Text = "Audit Log";
            tabPageAuditLog.UseVisualStyleBackColor = true;
            // 
            // listViewLog
            // 
            listViewLog.Dock = DockStyle.Fill;
            listViewLog.Location = new Point(3, 3);
            listViewLog.Name = "listViewLog";
            listViewLog.Size = new Size(825, 722);
            listViewLog.TabIndex = 0;
            listViewLog.TabStop = false;
            listViewLog.UseCompatibleStateImageBehavior = false;
            listViewLog.View = View.Details;
            // 
            // tabPageInventory
            // 
            tabPageInventory.Controls.Add(listViewInventory);
            tabPageInventory.Controls.Add(flowLayoutPanel2);
            tabPageInventory.Location = new Point(4, 24);
            tabPageInventory.Name = "tabPageInventory";
            tabPageInventory.Padding = new Padding(3);
            tabPageInventory.Size = new Size(831, 728);
            tabPageInventory.TabIndex = 1;
            tabPageInventory.Text = "Inventory";
            tabPageInventory.UseVisualStyleBackColor = true;
            // 
            // listViewInventory
            // 
            listViewInventory.Dock = DockStyle.Fill;
            listViewInventory.Location = new Point(3, 42);
            listViewInventory.Name = "listViewInventory";
            listViewInventory.Size = new Size(825, 683);
            listViewInventory.TabIndex = 1;
            listViewInventory.UseCompatibleStateImageBehavior = false;
            listViewInventory.View = View.Details;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(panel4);
            flowLayoutPanel2.Dock = DockStyle.Top;
            flowLayoutPanel2.Location = new Point(3, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(825, 39);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.AutoSize = true;
            panel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel4.Controls.Add(label3);
            panel4.Controls.Add(labelInventoryQuantityTotal);
            panel4.Controls.Add(buttonRefreshList);
            panel4.Controls.Add(checkBoxInventoryIncludeBlank);
            panel4.Controls.Add(comboBoxMatchValue);
            panel4.Controls.Add(comboBoxSearchByOptions);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(662, 29);
            panel4.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(247, 5);
            label3.Name = "label3";
            label3.Size = new Size(90, 15);
            label3.TabIndex = 6;
            label3.Text = "To match value:";
            // 
            // labelInventoryQuantityTotal
            // 
            labelInventoryQuantityTotal.AutoSize = true;
            labelInventoryQuantityTotal.Location = new Point(659, 6);
            labelInventoryQuantityTotal.Name = "labelInventoryQuantityTotal";
            labelInventoryQuantityTotal.Size = new Size(0, 15);
            labelInventoryQuantityTotal.TabIndex = 1;
            // 
            // buttonRefreshList
            // 
            buttonRefreshList.AutoSize = true;
            buttonRefreshList.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonRefreshList.Location = new Point(467, 1);
            buttonRefreshList.Name = "buttonRefreshList";
            buttonRefreshList.Size = new Size(74, 25);
            buttonRefreshList.TabIndex = 4;
            buttonRefreshList.TabStop = false;
            buttonRefreshList.Text = "RefreshList";
            buttonRefreshList.UseVisualStyleBackColor = true;
            buttonRefreshList.Click += buttonRefreshList_Click;
            // 
            // checkBoxInventoryIncludeBlank
            // 
            checkBoxInventoryIncludeBlank.AutoSize = true;
            checkBoxInventoryIncludeBlank.Checked = true;
            checkBoxInventoryIncludeBlank.CheckState = CheckState.Checked;
            checkBoxInventoryIncludeBlank.Location = new Point(547, 4);
            checkBoxInventoryIncludeBlank.Name = "checkBoxInventoryIncludeBlank";
            checkBoxInventoryIncludeBlank.Size = new Size(102, 19);
            checkBoxInventoryIncludeBlank.TabIndex = 1;
            checkBoxInventoryIncludeBlank.TabStop = false;
            checkBoxInventoryIncludeBlank.Text = "Include blanks";
            checkBoxInventoryIncludeBlank.UseVisualStyleBackColor = true;
            // 
            // comboBoxMatchValue
            // 
            comboBoxMatchValue.FormattingEnabled = true;
            comboBoxMatchValue.Location = new Point(340, 2);
            comboBoxMatchValue.Name = "comboBoxMatchValue";
            comboBoxMatchValue.Size = new Size(121, 23);
            comboBoxMatchValue.TabIndex = 3;
            comboBoxMatchValue.TabStop = false;
            // 
            // comboBoxSearchByOptions
            // 
            comboBoxSearchByOptions.FormattingEnabled = true;
            comboBoxSearchByOptions.Location = new Point(99, 2);
            comboBoxSearchByOptions.Name = "comboBoxSearchByOptions";
            comboBoxSearchByOptions.Size = new Size(145, 23);
            comboBoxSearchByOptions.TabIndex = 1;
            comboBoxSearchByOptions.TabStop = false;
            comboBoxSearchByOptions.SelectedIndexChanged += comboBoxSearchByOptions_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 4);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 0;
            label2.Text = "Search proprety:";
            // 
            // buttonAddManually
            // 
            buttonAddManually.AutoSize = true;
            buttonAddManually.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonAddManually.Location = new Point(695, 38);
            buttonAddManually.Name = "buttonAddManually";
            buttonAddManually.Size = new Size(91, 25);
            buttonAddManually.TabIndex = 107;
            buttonAddManually.Text = "&Add manually";
            buttonAddManually.UseVisualStyleBackColor = true;
            buttonAddManually.Click += buttonAddManually_Click;
            // 
            // Form1
            // 
            AcceptButton = buttonLookup;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(839, 866);
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
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPageAuditLog.ResumeLayout(false);
            tabPageInventory.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
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
        private ListView listViewLog;
        private Label labelError;
        private TextBox textBoxAlias;
        private TextBox textBoxStorageCode;
        private TabControl tabControl1;
        private TabPage tabPageAuditLog;
        private TabPage tabPageInventory;
        private FlowLayoutPanel flowLayoutPanel2;
        private Panel panel4;
        private Label label2;
        private ComboBox comboBoxMatchValue;
        private ComboBox comboBoxSearchByOptions;
        private Button buttonRefreshList;
        private ListView listViewInventory;
        private CheckBox checkBoxInventoryIncludeBlank;
        private Label label3;
        private Label labelInventoryQuantityTotal;
        private Panel panel5;
        private RadioButton radioButtonGoUpc;
        private RadioButton radioButtonBarcodeLookup;
        private Button buttonAddManually;
    }
}
