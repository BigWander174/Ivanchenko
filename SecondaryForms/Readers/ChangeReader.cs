using Ivanchenko.Model;

namespace Ivanchenko.SecondaryForms.Readers
{
    public partial class ChangeReader : Form
    {
        private int _selectedIndex;

        public Action<int, Reader> OnReaderChange;
        
        public ChangeReader()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var reader = new Reader()
            {
                Surname = textBox1.Text,
                Firstname = textBox2.Text,
                Lastname = textBox3.Text
            };

            OnReaderChange.Invoke(_selectedIndex, reader);
        }

        public void Set(DataGridViewRow row)
        {
            _selectedIndex = row.Index;
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            textBox3.Text = row.Cells[3].Value.ToString();
        }
    }
}
