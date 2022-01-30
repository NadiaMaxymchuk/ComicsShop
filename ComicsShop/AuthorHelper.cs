using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicsShop
{
    public class AuthorHelper
    {
        public static void AddAuthor()
        {
            Author author = new Author();

            Console.Write("Enter Author's FirstName: ");
            author.FirstName = Console.ReadLine();

            Console.Write("Enter Author's LastName: ");
            author.LastName = Console.ReadLine();

            Console.Write("Enter Author's BirthDate (DateTime): ");
            author.BirthDate = DateTime.Parse(Console.ReadLine());

            Program.authorService.AddAuthor(author);
        }

        public static void ShowAll()
        {
            var autor = Program.authorService.GetAll();
            short curentItem = 0;

            curentItem = MethodController.Menu(curentItem, autor.Select(t => t.FirstName + " " + t.LastName).ToArray());

            var tag = autor[curentItem];
            AuthorMenu(tag);
        }

        public static Author SelectAuthor()
        {
            var autor = Program.authorService.GetAll();
            short curentItem = 0;

            curentItem = MethodController.Menu(curentItem, autor.Select(t => t.FirstName + " " + t.LastName).ToArray(), "Select author");

            return autor[curentItem];            
        }
        static public void AuthorMenu(Author author)
        {
            short curItem = 0;
            string[] menuSelect = { "Edit First name", "Edit Last name", "Delete author", "Return to author menu", "Return to main menu", };

            switch (MethodController.Menu(curItem, menuSelect, $"Menu for tag: {author.FirstName} {author.LastName}"))
            {
                case 0: EditAuthorFirst(author); break;
                case 1: EditAuthorLast(author); break;
                case 2: Program.authorService.DeleteAuthor(author); break;
                case 3: MethodController.AuthorMenu(); break;
                case 4: MethodController.FirstMenu(); break;
            }
        }
        static public void EditAuthorFirst(Author author)
        {
            Console.WriteLine("Enter new First name");
            author.FirstName = Console.ReadLine();

            Program.authorService.UpdateAuthor(author);
            AuthorMenu(author);
        }

        static public void EditAuthorLast(Author author)
        {
            Console.WriteLine("Enter new Last name");
            author.LastName = Console.ReadLine();

            Program.authorService.UpdateAuthor(author);
            AuthorMenu(author);
        }


    }
}
