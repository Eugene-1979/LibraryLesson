using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LibraryLesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
          /*  Создаём массив книг*/
            Book[] books = Library.Generate(20, 6);

        /* тип сортировки по автору-названиюи*/
                Compare compare = Compare.title;

          /*  создаём библиотеку в зависимости от сортировки*/
            Library lb = new Library(compare);

            /*      добавляем книги ,раскидывая их по стеллажам и по сортировке
              a_k_EU,
              l_t_EU,
              u_z_UZ,
              а_к_RU,
              л_т_RU,
              у_я_RU
              digit
      */

            foreach (var item in books)
            {
                lb.AddBook(item);
            }

           /* выводим на печать отсортированную библиотеку по стеллажам*/
            Console.WriteLine(lb);
        }
    }


    public enum Alphabet
    {
        a_k_EU,
        l_t_EU,
        u_z_UZ,   
        а_к_RU,
        л_т_RU,
        у_я_RU, 
        digit

    }
    enum Compare
    {
        author,
        title
    }
   

   

}