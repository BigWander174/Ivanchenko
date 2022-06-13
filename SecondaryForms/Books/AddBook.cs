using Ivanchenko.Model;

namespace Ivanchenko.SecondaryForms.Books
{
    public partial class AddBook : Form
    {
        public Action<Book> OnNewBookAdd;
        
        public AddBook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox3.Text, out int result) && result > 0 && result < 6)
            {
                var book = new Book()
                {
                    Author = textBox1.Text,
                    Title = textBox2.Text,
                    SecureLevel = textBox3.Text
                };

                OnNewBookAdd.Invoke(book);
            }
        }
        
        private void AddBook_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
