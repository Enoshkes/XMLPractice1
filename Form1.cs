using System.Collections.Immutable;
using Windows.Repository;
using Windows.Service;

namespace Windows
{
    public partial class Form1 : Form
    {
        private const string PATH = "books.xml";
        public Form1()
        {
            InitializeComponent();
            ImmutableList<Book> library = InitializeBooks();
            BooksGridView.DataSource = library;

        }

        private ImmutableList<Book> InitializeBooks()
        {
            ImmutableList<Book> library = LibraryService.ReadXML(PATH);

            LibraryService.WriteXml(library, PATH);
            return library;
        }

        private void YearTextBoxKeyHandler(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool IsInvalidValues(params string[] values) =>
            values.Any(string.IsNullOrWhiteSpace);

        private void AddButtonClickHandler(object sender, EventArgs e)
        {
            string title = TitleTextBox.Text;
            string author = AuthorTextBox.Text;
            string year = YearTextBox.Text;

            if (IsInvalidValues(title, author, year))
            {
                MessageBox.Show("All fields must be filled");
                return;
            }

            bool isParsed = int.TryParse(year, out var parsed);

            if (!isParsed)
            {
                MessageBox.Show("Year can only contains digits");
                return;
            }

            var library = LibraryService.ReadXML(PATH);

            var newBook = new Book(title, author, parsed);

            if (library.Contains(newBook))
            {
                MessageBox.Show("Book already exists");
                return;
            }

            var withNewBook = LibraryService.AddBook(library, newBook);

            LibraryService.WriteXml(withNewBook, PATH);

            BooksGridView.DataSource = withNewBook;

        }
    }
}
