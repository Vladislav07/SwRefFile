namespace File_Reference
{
    partial class Form1
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
            this.VaultsLabel = new System.Windows.Forms.Label();
            this.VaultsComboBox = new System.Windows.Forms.ComboBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.CustRefListBox = new System.Windows.Forms.ListBox();
            this.AddCustomFileReference = new System.Windows.Forms.Button();
            this.CustRefOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // VaultsLabel
            // 
            this.VaultsLabel.AutoSize = true;
            this.VaultsLabel.Location = new System.Drawing.Point(13, 26);
            this.VaultsLabel.Name = "VaultsLabel";
            this.VaultsLabel.Size = new System.Drawing.Size(244, 13);
            this.VaultsLabel.TabIndex = 0;
            this.VaultsLabel.Text = "Copy a file to the clipboard, then select vault view:";
            // 
            // VaultsComboBox
            // 
            this.VaultsComboBox.FormattingEnabled = true;
            this.VaultsComboBox.Location = new System.Drawing.Point(16, 59);
            this.VaultsComboBox.Name = "VaultsComboBox";
            this.VaultsComboBox.Size = new System.Drawing.Size(121, 21);
            this.VaultsComboBox.TabIndex = 1;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(16, 98);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(271, 23);
            this.BrowseButton.TabIndex = 3;
            this.BrowseButton.Text = "Browse for file to which to add a custom reference...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // CustRefListBox
            // 
            this.CustRefListBox.FormattingEnabled = true;
            this.CustRefListBox.Location = new System.Drawing.Point(16, 150);
            this.CustRefListBox.Name = "CustRefListBox";
            this.CustRefListBox.Size = new System.Drawing.Size(259, 95);
            this.CustRefListBox.TabIndex = 4;
            // 
            // AddCustomFileReference
            // 
            this.AddCustomFileReference.Location = new System.Drawing.Point(16, 273);
            this.AddCustomFileReference.Name = "AddCustomFileReference";
            this.AddCustomFileReference.Size = new System.Drawing.Size(259, 23);
            this.AddCustomFileReference.TabIndex = 5;
            this.AddCustomFileReference.Text = "Add custom file reference";
            this.AddCustomFileReference.UseVisualStyleBackColor = true;
            this.AddCustomFileReference.Click += new System.EventHandler(this.AddCustomFileReference_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 308);
            this.Controls.Add(this.AddCustomFileReference);
            this.Controls.Add(this.CustRefListBox);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.VaultsComboBox);
            this.Controls.Add(this.VaultsLabel);
            this.Name = "Form1";
            this.Text = "Add custom file references";
            this.Load += new System.EventHandler(this.FileReferencesCSharp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label VaultsLabel;
        private System.Windows.Forms.ComboBox VaultsComboBox;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.ListBox CustRefListBox;
        private System.Windows.Forms.Button AddCustomFileReference;
        private System.Windows.Forms.OpenFileDialog CustRefOpenFileDialog;
    }
}

