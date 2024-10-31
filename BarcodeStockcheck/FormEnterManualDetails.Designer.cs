namespace BarcodeStockcheck
{
    partial class FormEnterManualDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBoxAddBarcode = new TextBox();
            textBoxAddPublisher = new TextBox();
            textBoxAddTitle = new TextBox();
            textBoxAddDescription = new TextBox();
            textBoxAddImageUrl = new TextBox();
            buttonAddOk = new Button();
            buttonAddCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 27);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 0;
            label1.Text = "Barcode:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 57);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 1;
            label2.Text = "Publisher:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(74, 87);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 2;
            label3.Text = "Title:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 118);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 3;
            label4.Text = "Description:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(48, 183);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 4;
            label5.Text = "ImageUrl:";
            // 
            // textBoxAddBarcode
            // 
            textBoxAddBarcode.Location = new Point(111, 24);
            textBoxAddBarcode.Name = "textBoxAddBarcode";
            textBoxAddBarcode.Size = new Size(100, 23);
            textBoxAddBarcode.TabIndex = 5;
            // 
            // textBoxAddPublisher
            // 
            textBoxAddPublisher.Location = new Point(111, 53);
            textBoxAddPublisher.Name = "textBoxAddPublisher";
            textBoxAddPublisher.Size = new Size(100, 23);
            textBoxAddPublisher.TabIndex = 6;
            // 
            // textBoxAddTitle
            // 
            textBoxAddTitle.Location = new Point(111, 84);
            textBoxAddTitle.Name = "textBoxAddTitle";
            textBoxAddTitle.Size = new Size(100, 23);
            textBoxAddTitle.TabIndex = 7;
            // 
            // textBoxAddDescription
            // 
            textBoxAddDescription.Location = new Point(111, 115);
            textBoxAddDescription.Multiline = true;
            textBoxAddDescription.Name = "textBoxAddDescription";
            textBoxAddDescription.Size = new Size(254, 52);
            textBoxAddDescription.TabIndex = 8;
            // 
            // textBoxAddImageUrl
            // 
            textBoxAddImageUrl.Location = new Point(111, 180);
            textBoxAddImageUrl.Name = "textBoxAddImageUrl";
            textBoxAddImageUrl.Size = new Size(100, 23);
            textBoxAddImageUrl.TabIndex = 9;
            // 
            // buttonAddOk
            // 
            buttonAddOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonAddOk.Location = new Point(317, 195);
            buttonAddOk.Name = "buttonAddOk";
            buttonAddOk.Size = new Size(75, 23);
            buttonAddOk.TabIndex = 10;
            buttonAddOk.Text = "Ok";
            buttonAddOk.UseVisualStyleBackColor = true;
            buttonAddOk.Click += buttonAddOk_Click;
            // 
            // buttonAddCancel
            // 
            buttonAddCancel.Location = new Point(236, 195);
            buttonAddCancel.Name = "buttonAddCancel";
            buttonAddCancel.Size = new Size(75, 23);
            buttonAddCancel.TabIndex = 11;
            buttonAddCancel.Text = "Cancel";
            buttonAddCancel.UseVisualStyleBackColor = true;
            // 
            // FormEnterManualDetails
            // 
            AcceptButton = buttonAddOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonAddCancel;
            ClientSize = new Size(404, 230);
            ControlBox = false;
            Controls.Add(buttonAddCancel);
            Controls.Add(buttonAddOk);
            Controls.Add(textBoxAddImageUrl);
            Controls.Add(textBoxAddDescription);
            Controls.Add(textBoxAddTitle);
            Controls.Add(textBoxAddPublisher);
            Controls.Add(textBoxAddBarcode);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormEnterManualDetails";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            TopMost = true;
            Load += FormEnterManualDetails_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBoxAddBarcode;
        private TextBox textBoxAddPublisher;
        private TextBox textBoxAddTitle;
        private TextBox textBoxAddDescription;
        private TextBox textBoxAddImageUrl;
        private Button buttonAddOk;
        private Button buttonAddCancel;
    }
}