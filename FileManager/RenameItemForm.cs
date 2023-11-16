using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public partial class RenameItemForm : Form
    {
        public Button OKButton { get => okButton; }
        public Button CancelButton { get => cancelButton; }
        public string InputTextBox { get => inputTextBox.Text; }
        public RenameItemForm(string defaultName)
        {
            InitializeComponent();
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
