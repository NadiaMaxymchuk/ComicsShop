using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicsShop
{
    public class ComicsHelper
    {
        public static void AddComics()
        {
            Comics comics = new Comics();
            Console.Write("Enter Comics Name: ");
            comics.Name = Console.ReadLine();

            Console.WriteLine("Enter page comics ");
            comics.Pages = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter order comics");
            comics.Order = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter IsSpecial comics");
            comics.IsSpecial = bool.Parse(Console.ReadLine());

            Console.WriteLine("Enter order comics");
            comics.PublishingHouse = Enum.Parse<PublishingHouse>(Console.ReadLine());

            comics.Author = AuthorHelper.SelectAuthor();

            Program.comicsService.AddComics(comics);
        }

        public static void ShowAll()
        {
            var comicses = Program.comicsService.GetAllComics();
            short curentItem = 0;

            curentItem = MethodController.Menu(curentItem, comicses.Select(t =>$"{t.Name} {t.Pages}").ToArray(), "Name\tPages");

            var comics = comicses[curentItem];
            ComicsMenu(comics);
        }

        static public void ComicsMenu(Comics comics)
        {
            short curItem = 0;
            string[] menuSelect = { "Edit comics", "Delete comics", "Return to comics' menu", "Return to main menu", };

            switch (MethodController.Menu(curItem, menuSelect, $"Menu for tag: {comics.Name}"))
            {
                case 0: EditName(comics); break;
                case 1: EditPage(comics); break;
                case 2: EditOrder(comics); break;
                case 3: Program.comicsService.DeleteComics(comics); break;
                case 4: MethodController.ComicsMenu(); break;
                case 5: MethodController.FirstMenu(); break;
            }
        }

        static public void EditName(Comics comics)
        {
            Console.WriteLine("Enter new name comics");
            comics.Name = Console.ReadLine();

            Program.comicsService.DeleteComics(comics);
            ComicsMenu(comics);
        }

        static public void EditPage(Comics comics)
        {
            Console.WriteLine("Enter new page comics");
            comics.Pages = int.Parse(Console.ReadLine());

            Program.comicsService.DeleteComics(comics);
            ComicsMenu(comics);
        }

        static public void EditOrder(Comics comics)
        {
            Console.WriteLine("Enter new order comics");
            comics.Order = int.Parse(Console.ReadLine());

            Program.comicsService.DeleteComics(comics);
            ComicsMenu(comics);
        }
    }
}
