using Ivanchenko.SecondaryForms.Books;
using Ivanchenko.SecondaryForms.Readers;
using Ivanchenko.SecondaryForms.IssuedBooks;
using Ivanchenko.Services;
using Ivanchenko.Views;

namespace Ivanchenko
{
    public partial class Form1 : Form
    {
        private AddBook _addBookForm;
        private AddReader _addReaderForm;
        private ChangeReader _changeReaderForm;
        private AddIssueBook _addIssueBookForm;
        private Tables _tables;

        private Service _service;

        public Action<int> OnReaderRemove;
        public Action<int> OnBookRemove;
        public Action<int> OnIssuedBookRemove;

        public Form1()
        {
            InitializeComponent();
        }

        private void addBookButton_Click(object sender, EventArgs e)
        {
            _addBookForm.ShowDialog();
        }

        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _changeReaderForm.Set(dataGridView2.Rows[e.RowIndex]);
        }

        private void addReaderButton_Click(object sender, EventArgs e)
        {
            _addReaderForm.ShowDialog();
        }

        private void changeReaderButton_Click(object sender, EventArgs e)
        {
            _changeReaderForm.ShowDialog();
        }

        private void deleteReaderButton_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
            OnReaderRemove.Invoke(id);
        }

        private void deleteBookButton_Click(object sender, EventArgs e)
        {
            var index = dataGridView1.SelectedRows[0].Index;
            OnBookRemove.Invoke(index);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _addBookForm = new AddBook();
            _addReaderForm = new AddReader();
            _changeReaderForm = new ChangeReader();
            _addIssueBookForm = new AddIssueBook();

            _service = new Service(_addBookForm, _addReaderForm, _changeReaderForm, _addIssueBookForm, this);
            _addIssueBookForm.AddService(_service);

            _tables = new Tables(dataGridView1, dataGridView2, dataGridView3, _service);
            _tables.Bind();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dataGridView3.SelectedRows[0].Cells[0].Value);
            OnIssuedBookRemove.Invoke(id);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            _addIssueBookForm.ShowDialog();
        }
    }
}