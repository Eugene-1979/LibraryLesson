using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLesson
{
    class Book : IEquatable<Book?>
    {
        public Book(int numberOfPages, Author myProperty, int yearofpublishing, string titleBook, string genre)
        {
     /*       if (numberOfPages < 1
                || myProperty == null
                || titleBook == null
                || genre == null
                || yearofpublishing < myProperty.AuthorBorn) throw new Exception("no good book");*/


            NumberOfPages = numberOfPages;
            MyProperty = myProperty;
            Yearofpublishing = yearofpublishing;
            TitleBook = titleBook;
            Genre = genre;
        }
        public override string ToString()
        {
            return $"Title {TitleBook,10} Autor {MyProperty,40} Genre{Genre,10}" +
                $" publ  {Yearofpublishing,4} Pages {NumberOfPages,4}";
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Book);
        }

        public bool Equals(Book? other)
        {
            return other is not null &&
                   NumberOfPages == other.NumberOfPages &&
                   EqualityComparer<Author>.Default.Equals(MyProperty, other.MyProperty) &&
                   Yearofpublishing == other.Yearofpublishing &&
                   TitleBook == other.TitleBook &&
                   Genre == other.Genre;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(NumberOfPages, MyProperty, Yearofpublishing, TitleBook, Genre);
        }

        public int NumberOfPages { get; init; }
        public Author MyProperty { get; init; }
        public int Yearofpublishing { get; init; }

        public string TitleBook { get; init; }
        public string Genre { get; init; }
    }

}
