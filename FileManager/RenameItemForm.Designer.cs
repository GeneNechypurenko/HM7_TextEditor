namespace FileManager
{
    partial class RenameItemForm
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
            inputTextBox = new TextBox();
            label1 = new Label();
            okButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // inputTextBox
            // 
            inputTextBox.Location = new Point(12, 48);
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(258, 27);
            inputTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(132, 20);
            label1.TabIndex = 1;
            label1.Text = "Enter New Name:";
            // 
            // okButton
            // 
            okButton.Location = new Point(12, 91);
            okButton.Name = "okButton";
            okButton.Size = new Size(120, 50);
            okButton.TabIndex = 2;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(150, 91);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(120, 50);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // RenameItemForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(282, 153);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(label1);
            Controls.Add(inputTextBox);
            MaximizeBox = false;
            Name = "RenameItemForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rename";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox inputTextBox;
        private Label label1;
        private Button okButton;
        private Button cancelButton;
    }
}