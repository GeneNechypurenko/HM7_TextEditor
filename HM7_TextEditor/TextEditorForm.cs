using System.Windows.Forms;

namespace HM7_TextEditor
{
    public partial class TextEditorForm : Form
    {
        private TextBox editorTextBox;
        private string fileName;
        public TextEditorForm()
        {
            Load += (s, e) =>
            {
                InitializeEditorTextBox();
                InitilizeMenu();
            };
            InitializeComponent();
        }
        private void InitilizeMenu()
        {
            MenuStrip menuStrip = new MenuStrip();
            AddFileMenu(menuStrip);
            AddEditMenu(menuStrip);
            AddFormatMenu(menuStrip);
            AddSettingsMenu(menuStrip);
            Controls.Add(menuStrip);
        }
        private void InitializeEditorTextBox()
        {
            editorTextBox = new TextBox()
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            Controls.Add(editorTextBox);
        }
        private void AddFileMenu(MenuStrip menuStrip)
        {
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("File");

            ToolStripMenuItem newFileItem = CreateMenuItem("New", Keys.Control | Keys.N, (s, e) => editorTextBox.Clear());
            ToolStripMenuItem openFileItem = CreateMenuItem("Open", Keys.Control | Keys.O, (s, e) => OpenFile());
            ToolStripMenuItem saveFileItem = CreateMenuItem("Save", Keys.Control | Keys.S, (s, e) => SaveDocument());

            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { newFileItem, openFileItem, saveFileItem });

            menuStrip.Items.Add(fileMenu);
        }
        private void AddEditMenu(MenuStrip menuStrip)
        {
            ToolStripMenuItem editMenu = new ToolStripMenuItem("Edit");

            ToolStripMenuItem copyItem = CreateMenuItem("Copy", Keys.Control | Keys.C, (s, e) => editorTextBox.Copy());
            ToolStripMenuItem cutItem = CreateMenuItem("Cut", Keys.Control | Keys.X, (s, e) => editorTextBox.Cut());
            ToolStripMenuItem pasteItem = CreateMenuItem("Paste", Keys.Control | Keys.V, (s, e) => editorTextBox.Paste());
            ToolStripMenuItem undoItem = CreateMenuItem("Undo", Keys.Control | Keys.Z, (s, e) => editorTextBox.Undo());

            editMenu.DropDownItems.AddRange(new ToolStripItem[] { copyItem, cutItem, pasteItem, undoItem });

            menuStrip.Items.Add(editMenu);
        }
        private void AddFormatMenu(MenuStrip menuStrip)
        {
            ToolStripMenuItem formatMenu = CreateMenuItem("Format", Keys.Control | Keys.F, (s, e) => ApplyFontSettings());
            menuStrip.Items.Add(formatMenu);
        }
        private void AddSettingsMenu(MenuStrip menuStrip)
        {
            ToolStripMenuItem settingsMenu = new ToolStripMenuItem("Settings");

            ToolStripMenuItem backGroundColorItem = CreateMenuItem("Background Color", Keys.Control | Keys.E, (s, e) => SetBackgroundColor());
            ToolStripMenuItem textColorItem = CreateMenuItem("Text Color", Keys.Control | Keys.R, (s, e) => SetTextColor());

            settingsMenu.DropDownItems.AddRange(new ToolStripItem[] { backGroundColorItem, textColorItem });

            menuStrip.Items.Add(settingsMenu);
        }
        private ToolStripMenuItem CreateMenuItem(string text, Keys shortcutKeys, EventHandler eventHandler)
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem(text) { ShortcutKeys = shortcutKeys };
            menuItem.Click += eventHandler;
            return menuItem;
        }
        private void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                editorTextBox.Text = File.ReadAllText(fileName);
            }
        }
        private void SaveDocument()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                FileName = "New Document.txt"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
                File.WriteAllText(fileName, editorTextBox.Text);
            }
        }
        private void SetBackgroundColor()
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK) { editorTextBox.BackColor = colorDialog.Color; }
        }
        private void SetTextColor()
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK) { editorTextBox.ForeColor = colorDialog.Color; }
        }
        private void ApplyFontSettings()
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK) { editorTextBox.Font = fontDialog.Font; }
        }
        private void TextEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (editorTextBox.Text != string.Empty)
            {
                DialogResult result = MessageBox.Show("Save current Document to File and close Dialog Window?", "Close Program?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes) { SaveDocument(); }
                else if (result == DialogResult.No) { e.Cancel = false; }
                else { e.Cancel = true; }
            }
        }
    }
}