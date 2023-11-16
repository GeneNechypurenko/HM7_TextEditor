using System.Text;

namespace HiddenContentPanel
{
    public partial class MainForm : Form
    {
        private Panel hiddenPanel;
        private Button showHiddenContentButton;
        private MenuStrip menuStrip;

        public MainForm()
        {
            Load += (s, e) =>
            {
                menuStrip = new MenuStrip
                {
                    BackColor = Color.SteelBlue,
                };

                ToolStripLabel label = new ToolStripLabel
                {
                    Text = CenterText("MENU"),
                    Font = new Font(Font.FontFamily, 16, FontStyle.Bold),
                    ForeColor = Color.White,
                };

                menuStrip.Items.Add(label);

                showHiddenContentButton = new Button
                {
                    Text = "Show Content",
                    Location = new Point((Width - 150) / 2, Height / 2),
                    Size = new Size(150, 30)
                };

                showHiddenContentButton.Click += (s, e) => hiddenPanel.Visible = !hiddenPanel.Visible;

                hiddenPanel = new Panel
                {
                    Width = 200,
                    Height = Height,
                    BackColor = Color.Gray,
                    Visible = false,
                    Location = new Point(Width - 200, 0)
                };

                Label hiddenLabel = new Label
                {
                    Text = "Content",
                    Location = new Point(50, 50),
                    Size = new Size(100, 20),
                    ForeColor = Color.White
                };

                TextBox hiddenTextBox = new TextBox
                {
                    Location = new System.Drawing.Point(50, 80),
                    Size = new System.Drawing.Size(100, 20)
                };

                Button hiddenButton = new Button
                {
                    Text = "Button",
                    Location = new System.Drawing.Point(50, 110),
                    Size = new System.Drawing.Size(100, 30)
                };

                hiddenPanel.Controls.Add(hiddenLabel);
                hiddenPanel.Controls.Add(hiddenTextBox);
                hiddenPanel.Controls.Add(hiddenButton);

                Controls.Add(menuStrip);
                Controls.Add(showHiddenContentButton);
                Controls.Add(hiddenPanel);

                Resize += (s, e) =>
                {
                    showHiddenContentButton.Location = new System.Drawing.Point((Width - 150) / 2, Height / 2);
                    hiddenPanel.Location = new System.Drawing.Point(Width - 200, 0);
                };
            };
            InitializeComponent();
        }
        private string CenterText(string text)
        {
            int offset = (menuStrip.Width - TextRenderer.MeasureText(text, new Font(Font.FontFamily, 16, FontStyle.Bold)).Width) / 2;
            return new string(' ', offset) + text;
        }
    }
}