using Ivanchenko.Model;
using Ivanchenko.Contexts;
using Ivanchenko.SecondaryForms.Books;
using Ivanchenko.SecondaryForms.Readers;
using Ivanchenko.SecondaryForms.IssuedBooks;

namespace Ivanchenko.Services
{
    public class Service
    {
        private Context _context;

        public Action UpdatePresenter;

        public Service(AddBook addBook, AddReader addReaderForm, ChangeReader changeReader, AddIssueBook addIssueBookForm, Form1 form)
        {
            _context = new Context();
            addBook.OnNewBookAdd += Add;
            addReaderForm.OnReaderAdd += Add;
            addIssueBookForm.OnIssueBookAdd += Add;
            changeReader.OnReaderChange += Change;
            form.OnBookRemove += RemoveBook;
            form.OnReaderRemove += RemoveReader;
            form.OnIssuedBookRemove += RemoveIssueBook;
            UpdatePresenter += SaveInDB;
        }

        public List<Book> Books => _context.Books.ToList();
        public List<Reader> Readers => _context.Readers.ToList();
        public List<IssueBook> IssueBook => _context.IssueBooks.ToList();

        private void Add(Book book)
        {
            var bookWithTheSameTitle = _context.Books.ToList().FirstOrDefault(element => element.Title == book.Title);
            if (bookWithTheSameTitle == null)
            {
                _context.Books.Add(book);
                UpdatePresenter.Invoke();
            }
        }

        private void RemoveBook(int index)
        {
            _context.Books.Remove(_context.Books.ToList()[index]);
            UpdatePresenter.Invoke();
        }

        private void Add(Reader reader)
        {
            var readerWithTheSameName = _context.Readers.ToList().FirstOrDefault(element => element.IsEqual(reader));

            if (readerWithTheSameName == null)
            {
                _context.Readers.Add(reader);
                UpdatePresenter?.Invoke();
            }
        }

        private void RemoveReader(int id)
        {
            var readerToDelete = _context.Readers.First(reader => reader.Id == id);
            _context.Readers.Remove(readerToDelete);
            UpdatePresenter.Invoke();
        }

        private void Add(IssueBook issueBook)
        {
            _context.IssueBooks.Add(issueBook);
            UpdatePresenter.Invoke();
        }

        private void Change(int index, Reader reader)
        {
            var readerToChange = _context.Readers.ToList()[index];
            readerToChange.Surname = reader.Surname;
            readerToChange.Firstname = reader.Firstname;
            readerToChange.Lastname = reader.Lastname;
            UpdatePresenter.Invoke();
        }

        private void RemoveIssueBook(int id)
        {
            var bookToDelete = _context.IssueBooks.First(book => book.Id == id);
            _context.IssueBooks.Remove(bookToDelete);
            UpdatePresenter.Invoke();
        }

        private void SaveInDB()
        {
            _context.SaveChanges();
        }
    }
}
