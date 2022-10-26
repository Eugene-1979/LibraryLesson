using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLesson
{
    class Library
    {
        private ComparePerson comPers;

        public Compare CompereAuthorTitle { get; init; }

        private Shelf[] mas;
        private class ComparePerson : IComparer<Book>
        {
            private Library lib;
            public ComparePerson(Library lib)
            {
                this.lib = lib;
            }

            public int Compare(Book? x, Book? y)

            {
                switch (lib.CompereAuthorTitle)
                {
                    case LibraryLesson.Compare.author:
                        return (x.MyProperty.ToString() + x.TitleBook).
                                 CompareTo(y.MyProperty.ToString() + y.TitleBook);
                        break;
                    case LibraryLesson.Compare.title:
                        return (x.TitleBook + x.MyProperty.ToString()).
                                  CompareTo(y.TitleBook + y.MyProperty.ToString());
                        break;
                         default: return 0;
                
                }

            }

        }

       /* Генерируем книги с именем автора. 1буква заглавная.Рандомно автор -укр\анг и Жив\не жив*/
        static public Book[] Generate(int val, int lenWord)
        {
            string english = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string ukr = "АБВГДЕЖЗИКЛМНОПРСТУФХЧШЩЬЮЯ";
            char[] UpplettersEng = english.ToCharArray();
            char[] lettersEng = english.ToLower().ToCharArray();
            char[] digit = "1234567890".ToCharArray();
            char[] UpplettersUkr = ukr.ToCharArray();
       /*     char[] UpplettersUkr = UnicodeEncoding.UTF8.GetChars(Encoding.UTF8.GetBytes(ukr));*/
                


            char[] lettersUkr = ukr.ToLower().ToCharArray();

            Book[] book = new Book[val];
            Random rnd = new Random();

            for (int i = 0; i < val; i++)
            {
                int born = rnd.Next(DateTime.Now.Year - 15);
                int dead = rnd.Next(born, DateTime.Now.Year);
                int yyy = rnd.Next(16) % 4;
                book[i] = yyy switch
                {
                    /*english not dead*/
                    0 => new Book(rnd.Next(1000),
                            new Author(generateWord(UpplettersEng, lettersEng, lenWord),
                            generateWord(UpplettersEng, lettersEng, lenWord),
                            rnd.Next(born)),

                            rnd.Next(DateTime.Now.Year - 15),

                    generateWord(UpplettersEng, lettersEng, lenWord),
                    generateWord(UpplettersEng, lettersEng, lenWord)),

                    /* english dead*/
                    1 => new Book(rnd.Next(1000),
                                new Author(generateWord(UpplettersEng, lettersEng, lenWord),
                                generateWord(UpplettersEng, lettersEng, lenWord),
                               born, dead),

                                rnd.Next(DateTime.Now.Year - 15),

                        generateWord(UpplettersEng, lettersEng, lenWord),
                        generateWord(UpplettersEng, lettersEng, lenWord)),

                    /*ukr nor diad*/
                    2 => new Book(rnd.Next(1000),
                            new Author(generateWord(UpplettersUkr, lettersUkr, lenWord),
                            generateWord(UpplettersUkr, lettersUkr, lenWord),
                            born),

                            rnd.Next(DateTime.Now.Year - 15),

                    generateWord(UpplettersUkr, lettersUkr, lenWord),
                    generateWord(UpplettersUkr, lettersUkr, lenWord)),

                    /* ukr diad*/
                    3 => new Book(rnd.Next(1000),
                            new Author(generateWord(UpplettersUkr, lettersUkr, lenWord),
                            generateWord(UpplettersUkr, lettersUkr, lenWord),
                            born, dead),

                            rnd.Next(DateTime.Now.Year - 15),

                    generateWord(UpplettersUkr, lettersUkr, lenWord),
                    generateWord(UpplettersUkr, lettersUkr, lenWord))

                };
            }
            return book;

            /*Генереруем слово,в зависимости от кол-ва букв и языка*/
            string generateWord(char[] firstLetter, char[] letter, int lenWord)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(firstLetter[rnd.Next(firstLetter.Length)]);
                for (int i = 0; i < lenWord; i++)
                {
                    sb.Append(letter[rnd.Next(letter.Length)]);
                }
                return sb.ToString();
            }

        }

        
        public Library(Compare compereAuthorTitle)
        {
            CompereAuthorTitle = compereAuthorTitle;
            comPers = new Library.ComparePerson(this);
            int temp = Enum.GetValues(typeof(Alphabet)).Length;
            mas = new Shelf[temp];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = new Shelf((Alphabet)i, this);
            }


        }
        /* Добавление книги в библиотеку*/
        public bool AddBook(Book book)
        {

            /*В зависимости от сортировки по автору или 
                по названию определяем 1ю букву,а затем раскидіваем в стежи Shelf,
                во которых SortedSet отсортированные книги в зависимости от сортировки Compare*/

            char FirstChar = char.MaxValue;
            switch (CompereAuthorTitle)
            {

                case Compare.author:
                    FirstChar = book.MyProperty.FirstName.ToLower()[0];


                    break;
                case Compare.title:
                    FirstChar = book.TitleBook.ToLower()[0];
                    break;
            }



            int NumberShelt = FirstChar switch
            {
                >= 'a' and <= 'k' => 0,
                >= 'l' and <= 't' => 1,
                >= 'u' and <= 'z' => 2,
                >= 'а' and <= 'к' => 3,
                >= 'л' and <= 'т' => 4,
                >= 'у' and <= 'я' => 5,
               _=>6
            };


            SortedSet<Book> sbb = mas[NumberShelt].books;
           bool rez= sbb.Add(book);
            return rez;
           /* return mas[NumberShelt].books.Add(book);*/

        }

        private class Shelf
        {
            public Shelf(Alphabet alth, Library lib)
            {
                this.alth = alth;
                books = new SortedSet<Book>(lib.comPers);

            }
            public SortedSet<Book> books { get; init; }
            public Alphabet alth { get; init; }


        }
        public override string ToString()
        {

            StringBuilder sb = new StringBuilder().
                Append(CompereAuthorTitle).
                Append(Environment.NewLine).Append(Environment.NewLine);




            for (int i = 0; i < mas.Length; i++)
            {
                sb.Append($"--------{(Alphabet)i}").
                    Append(Environment.NewLine).Append(Environment.NewLine);
                SortedSet<Book> books = mas[i].books;
                foreach (var item in books)
                {
                    sb.Append(item).Append(Environment.NewLine);
                }
                sb.Append(Environment.NewLine);
            }



            return sb.ToString();
        }

    }
}
