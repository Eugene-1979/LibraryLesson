using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLesson
{
    class Author
    {


        public Author(string firstName, string lastName, int authorBorn)
            : this(firstName, lastName, authorBorn, DateTime.Now.Year)
        {
            IsAlive = true;
        }

        public Author(string firstName, string lastName, int authorBorn, int yearOfDeath)
        {
            
        /*    if ((yearOfDeath - authorBorn) < 0 || yearOfDeath > DateTime.Now.Year
                || authorBorn < 100000|| firstName==null||lastName==null)
                throw new ArgumentException("no autor");*/
            
            FirstName = firstName;
            LastName = lastName;
            AuthorBorn = authorBorn;
            YearOfDeath = yearOfDeath;
            IsAlive = false;



            

        }
        public bool IsAlive { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int AuthorBorn { get; init; }
        public int YearOfDeath { get; init; }



        public override string ToString()
        {
            return IsAlive ?

                $"FN {FirstName,10} LN {LastName,10} Born {AuthorBorn,4} {"",11 }":
                $"FN {FirstName,10} LN {LastName,10} Born {AuthorBorn,4} -Death {YearOfDeath,4}";

            /* return $"Author {FirstName} {LastName} AuthorBorn {AuthorBorn}"+IsAlive ? "" : "kmm";*/


        }



    }
}
