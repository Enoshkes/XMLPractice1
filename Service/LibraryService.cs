using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Repository;

namespace Windows.Service
{
    internal static class LibraryService
    {

        private static Book? ProcessBook(XElement book)
        {
            bool parsed = int.TryParse(book.Element("year")?.Value, out int year);
            if (!parsed)
            {
                return null;
            }
            var title = book.Element("title")?.Value ?? string.Empty;
            var author = book.Element("author")?.Value ?? string.Empty;

            ImmutableList<string> validations = [title, author];

            if (validations.Any(string.IsNullOrWhiteSpace))
            {
                return null;
            }

            return new(title, author, year);
        }

        public static ImmutableList<Book> ReadXML(string path)
        {
            try
            {
                var doc = XDocument.Load(path);
                return doc.Descendants("book")
                    .Select(ProcessBook)
                    .Where(x => x != null)
                    .Select(x => x!)
                    .ToImmutableList();
            }
            catch (Exception)
            {
                return [];
            }
        }

        public static void WriteXml(ImmutableList<Book> books, string path)
        {
            var doc = new XDocument(
                new XElement("library",
                    books.Select(book =>
                        new XElement("book",
                            new XElement("title", book.Title),
                            new XElement("author", book.Author),
                            new XElement("year", book.Year)
                        )
                    )
                )
            );
            doc.Save(path);
        }

        public static ImmutableList<Book> AddBook(ImmutableList<Book> books, Book newBook) =>
            books.Add(newBook);

        public static ImmutableList<Book> RemoveBook(ImmutableList<Book> books, string title) =>
            throw new NotImplementedException();

        public static ImmutableList<Book> UpdateYear(ImmutableList<Book> books, string title, int newYear) =>
            throw new NotImplementedException();

        public static ImmutableList<Book> FilterByAuthor(ImmutableList<Book> books, string author) =>
            throw new NotImplementedException();

    }
}
