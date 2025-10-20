using System;
using System.Drawing;
using System.Security.Policy;

namespace up7
{
    public partial class Form1 : Form
    {
        private int rows = 4;
        private int columns = 3;
        Random rnd = new Random();
        List<string> icons = new List<string>()
        {
            "!", "!", ")", "(", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z",
            "p", "p", "q", "q","r", "r", "t", "t",
            "u", "u","i", "i", "o", "o", "a", "a",
            "s", "s", "f", "f", "g", "g","h", "h",
            "l", "l", "x", "x", "c", "c", "n", "n",
            "й","й", "ц", "ц", "у", "у", "к", "к",
            "е", "е", "н", "н", "г", "г", "ш", "ш",

        };
        Label firstClicked = null;
        Label secondClicked = null;
        public Form1()
        {
            InitializeComponent();
            CreateTable();
            AssignIconsToSquares();
        }
        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = rnd.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;
            Label clickedLabel = sender as Label;
            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;
                CheckForWinner();
                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
                timer1.Start();
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            firstClicked = null;
            secondClicked = null;
        }
        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                    {
                        return;
                    }
                }
            }
            MessageBox.Show("Поздравляем, вы выиграли!");
            Close();
        }
        private void CreateTable()
        {
            if (Controls.Contains(tableLayoutPanel1))
            {
                Controls.Remove(tableLayoutPanel1);
            }
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.BackColor = Color.CornflowerBlue;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel1.ColumnCount = columns;
            tableLayoutPanel1.RowCount = rows;
            int width = 100 / tableLayoutPanel1.ColumnCount;
            int height = 100 / tableLayoutPanel1.RowCount;
            for (int i = 0; i < columns; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, width));
            }
            for (int i = 0; i < rows; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, height));
            }
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Label label = new Label();
                    label.Dock = DockStyle.Fill;
                    label.Font = new Font("Webdings", 48, FontStyle.Bold);
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.Click += label1_Click;
                    tableLayoutPanel1.Controls.Add(label, j, i);
                }
            }
            Controls.Add(tableLayoutPanel1);


        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

