using Ivanchenko.Services;

namespace Ivanchenko.Views
{
    public class Tables
    {
        private DataGridView _booksTable;
        private DataGridView _readersTable;
        private DataGridView _issuedBookTable;
        private Service _service;

        public Tables(DataGridView booksTable, DataGridView readersTable, DataGridView issuedTable, Service service)
        {
            _booksTable = booksTable;
            _readersTable = readersTable;
            _issuedBookTable = issuedTable;
            _service = service;
            service.UpdatePresenter += Bind;
        }

        internal void Bind()
        {
            _booksTable.DataSource = _service.Books;
            _readersTable.DataSource = _service.Readers;
            _issuedBookTable.DataSource = _service.IssueBook;
        }
    }
}
