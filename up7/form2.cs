namespace up7
{
    public partial class form2 : Form
    {
        public form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 forma = new Form1();
            // form2 forma2 = new form2();
            forma.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 forma = new Form1();
            forma.ShowDialog();
           
        }
    }
}
