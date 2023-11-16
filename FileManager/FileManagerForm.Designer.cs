namespace FileManager
{
    partial class FileManagerForm
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
            menuStrip = new MenuStrip();
            addressBarTextBox = new TextBox();
            treeViewPanel = new Panel();
            listViewPanel = new Panel();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // addressBarTextBox
            // 
            addressBarTextBox.Dock = DockStyle.Top;
            addressBarTextBox.Location = new Point(0, 24);
            addressBarTextBox.Name = "addressBarTextBox";
            addressBarTextBox.ReadOnly = true;
            addressBarTextBox.Size = new Size(800, 27);
            addressBarTextBox.TabIndex = 1;
            // 
            // treeViewPanel
            // 
            treeViewPanel.Dock = DockStyle.Left;
            treeViewPanel.Location = new Point(0, 51);
            treeViewPanel.Name = "treeViewPanel";
            treeViewPanel.Size = new Size(200, 399);
            treeViewPanel.TabIndex = 2;
            // 
            // listViewPanel
            // 
            listViewPanel.Dock = DockStyle.Fill;
            listViewPanel.Location = new Point(200, 51);
            listViewPanel.Name = "listViewPanel";
            listViewPanel.Size = new Size(600, 399);
            listViewPanel.TabIndex = 3;
            // 
            // FileManagerForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listViewPanel);
            Controls.Add(treeViewPanel);
            Controls.Add(addressBarTextBox);
            Controls.Add(menuStrip);
            Name = "FileManagerForm";
            Text = "File Manager";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private TextBox addressBarTextBox;
        private Panel treeViewPanel;
        private Panel listViewPanel;
    }
}