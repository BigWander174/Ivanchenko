using Ivanchenko.Model;
using Ivanchenko.SecondaryForms.Books;
using Ivanchenko.SecondaryForms.Readers;
using Ivanchenko.Services;

namespace Ivanchenko.SecondaryForms.IssuedBooks
{
    public partial class AddIssueBook : Form
    {
        private ComboBoxFiller _comboBoxFiller;

        public Action<IssueBook> OnIssueBookAdd;

        public AddIssueBook()
        {
            InitializeComponent();
            _comboBoxFiller = new ComboBoxFiller(comboBox1, comboBox2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var issueBook = new IssueBook()
                {
                    BookId = int.Parse(comboBox1.Text),
                    ReaderId = int.Parse(comboBox2.Text),
                    IssueDate = textBox1.Text
                };

                OnIssueBookAdd.Invoke(issueBook);
            }
            catch
            {
                Clear();
            }
        }

        private void AddIssueBook_FormClosing(object sender, FormClosingEventArgs e)
        {
            Clear();
        }

        internal void AddService(Service service)
        {
            _comboBoxFiller.SetService(service);
        }

        private void Clear()
        {
            comboBox1.Text = String.Empty;
            comboBox2.Text = String.Empty;
            textBox1.Clear();
        }
    }
}
