using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace FileManager
{
    public partial class FileManagerForm : Form
    {
        private DriveInfo[] drives = DriveInfo.GetDrives();
        private DirectoryInfo currentDirectory;

        private TreeView treeView;
        private ListView listView;
        private ContextMenuStrip contextMenuStrip;
        RenameItemForm renameItemForm;

        public FileManagerForm()
        {
            Load += (s, e) =>
            {
                InitializeTreeView();
                InitilizeListView();
                InitializeMenuStrip();
                InitializeContextMenuStrip();
            };
            InitializeComponent();
        }

        private void InitializeContextMenuStrip()
        {
            contextMenuStrip = new ContextMenuStrip();
            contextMenuStrip.Items.Add("Delete", null, (s, e) => Delete());
            contextMenuStrip.Items.Add("Rename", null, (s, e) => Rename());
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            contextMenuStrip.Items.Add("Back", null, (s, e) => Back());

            listView.ContextMenuStrip = contextMenuStrip;
        }

        private void InitializeMenuStrip()
        {
            var fileMenu = new ToolStripMenuItem("File");
            var backMenu = new ToolStripMenuItem("Back", null, (s, e) => Back());
            var exitMenu = new ToolStripMenuItem("Exit", null, (s, e) => Application.Exit());

            var deleteMenuItem = new ToolStripMenuItem("Delete", null, (s, e) => Delete())
            {
                ShortcutKeys = Keys.Delete
            };
            var renameMenuItem = new ToolStripMenuItem("Rename", null, (s, e) => Rename())
            {
                ShortcutKeys = Keys.F2
            };
            var backMenuItem = new ToolStripMenuItem("Back", null, (s, e) => Back())
            {
                ShortcutKeys = Keys.Alt | Keys.Left
            };
            var exitMenuItem = new ToolStripMenuItem("Exit", null, (s, e) => Application.Exit());

            fileMenu.DropDownItems.Add(deleteMenuItem);
            fileMenu.DropDownItems.Add(renameMenuItem);
            fileMenu.DropDownItems.Add(new ToolStripSeparator());
            fileMenu.DropDownItems.Add(backMenuItem);
            fileMenu.DropDownItems.Add(new ToolStripSeparator());
            fileMenu.DropDownItems.Add(exitMenuItem);

            var menuItems = new ToolStripMenuItem[] { fileMenu, backMenu, exitMenu };

            menuStrip.Items.AddRange(menuItems);
        }


        private void InitilizeListView()
        {
            listView = new ListView();

            listView.Columns.Add("Name", 300);
            listView.Columns.Add("Type", 100);
            listView.Columns.Add("Write Time", 196);

            listViewPanel.Controls.Add(listView);

            listView.Dock = DockStyle.Fill;
            listView.View = View.Details;

            listView.DoubleClick += (s, e) =>
            {
                string fileName = listView.SelectedItems[0].Text;
                string path = Path.Combine(currentDirectory.FullName, fileName);

                if (File.Exists(path)) { System.Diagnostics.Process.Start("explorer.exe", "/select," + path); }
                else if (Directory.Exists(path)) { OpenDirectory(path); }
            };
        }
        private void InitializeTreeView()
        {
            treeView = new TreeView();
            treeViewPanel.Controls.Add(treeView);
            treeView.Dock = DockStyle.Fill;

            foreach (var drive in drives)
            {
                TreeNode driveNode = new TreeNode(drive.Name);
                treeView.Nodes.Add(driveNode);

                foreach (var directory in Directory.GetDirectories(drive.Name))
                {
                    driveNode.Nodes.Add(new TreeNode(Path.GetFileName(directory)));
                }
            }

            treeView.DoubleClick += (s, e) => OpenDirectory(treeView.SelectedNode.FullPath);
        }

        private void OpenDirectory(string fullPath)
        {
            listView.Items.Clear();

            currentDirectory = new DirectoryInfo(fullPath);
            addressBarTextBox.Text = currentDirectory.FullName;

            foreach (var directory in currentDirectory.GetDirectories())
            {
                FileItem item = new FileItem(directory.Name, "🗀 Directory", directory.LastWriteTime);
                AddItemToListView(item);
            }

            foreach (var file in currentDirectory.GetFiles())
            {
                FileItem item = new FileItem(file.Name, "🗋 File", file.LastWriteTime);
                AddItemToListView(item);
            }
        }

        private void AddItemToListView(FileItem item)
        {
            ListViewItem listViewItem = new ListViewItem(item.Name);
            listViewItem.SubItems.Add(item.Type);
            listViewItem.SubItems.Add(item.LastWriteTime.ToString());
            listView.Items.Add(listViewItem);
        }
        private void Delete() // ОСТОРОЖНО МЕТОД УДАЛЯЕТ КОНТЕНТ НЕ ПЕРЕМЕЩАЯ В КОРЗИНУ (БЕЗВОЗВРАТНО)!!!
        {
            if (listView.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show
                    ("ОСТОРОЖНО МЕТОД УДАЛЯЕТ КОНТЕНТ НЕ ПЕРЕМЕЩАЯ В КОРЗИНУ (БЕЗВОЗВРАТНО)!!!" +
                    "\nОДУМАЙТЕСЬ!!! НЕ СОВЕРШАЙТЕ МОИХ ОШИБОК!!! ЖИЗНЬ ОДНА!!!",
                    "УДАЛЕНИЕ КОНТЕНТА!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    string selectedItemName = listView.SelectedItems[0].Text;
                    string selectedItemPath = Path.Combine(currentDirectory.FullName, selectedItemName);

                    if (File.Exists(selectedItemPath)) { File.Delete(selectedItemPath); }
                    else if (Directory.Exists(selectedItemPath)) { Directory.Delete(selectedItemPath, true); }

                    OpenDirectory(currentDirectory.FullName);
                }
            }
        }
        private void Rename()
        {
            if (listView.SelectedItems.Count > 0)
            {
                string selectedItemName = listView.SelectedItems[0].Text;
                string selectedItemPath = Path.Combine(currentDirectory.FullName, selectedItemName);

                string newName = ShowRenameItemForm(selectedItemName);

                if (!string.IsNullOrEmpty(newName))
                {
                    string newPath = Path.Combine(currentDirectory.FullName, newName);

                    try
                    {
                        if (File.Exists(selectedItemPath)) { File.Move(selectedItemPath, newPath); }
                        else if (Directory.Exists(selectedItemPath)) { Directory.Move(selectedItemPath, newPath); }

                        OpenDirectory(currentDirectory.FullName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error renaming: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private string ShowRenameItemForm(string defaultName)
        {
            using (renameItemForm = new RenameItemForm(defaultName))
            {
                var result = renameItemForm.ShowDialog();
                return result == DialogResult.OK ? renameItemForm.InputTextBox : string.Empty;
            }
        }
        private void Back()
        {
            if (currentDirectory?.Parent != null)
            {
                OpenDirectory(currentDirectory.Parent.FullName);
            }
        }
    }
}