using Ivanchenko.Model;

namespace Ivanchenko.SecondaryForms.Readers
{
    public partial class AddReader : Form
    {
        public Action<Reader> OnReaderAdd;
        
        public AddReader()
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

            OnReaderAdd.Invoke(reader);
        }
        
        private void AddReader_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
