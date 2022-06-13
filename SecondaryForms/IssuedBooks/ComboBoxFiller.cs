using Ivanchenko.Services;

namespace Ivanchenko.SecondaryForms.IssuedBooks
{
    internal class ComboBoxFiller
    {
        private ComboBox _readersId;
        private ComboBox _booksId;
        private Service _service;

        public ComboBoxFiller(ComboBox bookId, ComboBox readersId)
        {
            _readersId = readersId;
            _booksId = bookId;
        }

        public void Fill()
        {
            _readersId.Items.Clear();
            _readersId.Items.AddRange(_service.Readers.Select(reader => (object)reader.Id).ToArray());

            var elements = _service.Books.Select(book => book.Id).ToArray().Except(_service.IssueBook.Select(element => element.BookId));
            _booksId.Items.Clear();
            _booksId.Items.AddRange(elements.Select(element => (object)element).ToArray());

            _readersId.Text = String.Empty;
            _booksId.Text = String.Empty;
        }

        internal void SetService(Service service)
        {
            service.UpdatePresenter += Fill;
            _service = service;
            Fill();
        }
    }
}
