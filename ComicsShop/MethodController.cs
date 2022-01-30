using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicsShop
{
    public class MethodController

    {
        static public void TagsMenu()
        {
            short curItem = 0;
            string[] menuSelect = { "Add new tag ", "Show Tags ","Find Tag ", "Return to main menu ", };

            switch (Menu(curItem, menuSelect))
            {
                case 0: TagHelper.AddTag(); break;
                case 1: TagHelper.ShowAll(); break;
                case 2: TagHelper.FindTagMenu(); break;
                case 3: FirstMenu(); break;

            }
        }
        static public void AuthorMenu()
        {
            short curItem = 0;
            string[] menuSelect = { "Add new author ", "Show all autors ", "Find author ", "Return to main menu ", };

            switch (Menu(curItem, menuSelect))
            {
                case 0: AuthorHelper.AddAuthor(); break;
                case 1: AuthorHelper.ShowAll(); break;
                case 2: AuthorHelper.FindAuthorMenu(); break;
                case 3: FirstMenu(); break;

            }
        }
        static public void ComicsMenu()
        {
            short curItem = 0;
            string[] menuSelect = { "Add new comics ", "Show all comics ", "Find comics ", "Return to main menu ", };

            switch (Menu(curItem, menuSelect))
            {
                case 0: ComicsHelper.AddComics(); break;
                case 1: ComicsHelper.ShowAll(); break;
                case 2: ComicsHelper.FindComicsMenu(); break;
                case 3: FirstMenu(); break;

            }
        }

        public static void FirstMenu()
        {
            short curItem = 0;
            string[] menuItems= new string[] {"Tag", "Author", "Comics",  "Exit"};

            switch (Menu(curItem, menuItems))
            {
                case 0: TagsMenu(); break;
                case 1: AuthorMenu(); break;
                case 2: ComicsMenu(); break;
                case 3: Program.Work = false; return;
            }
        }

        static public short Menu(short curItem, string[] MenuText,string menuName = "[ MENU ]")
        {
            ConsoleKeyInfo key;
            short c;
            do
            {
                Console.Clear();
                Console.WriteLine(menuName);

                for (c = 0; c < MenuText.Length; c++)
                {

                    if (curItem == c)
                    {
                        Console.Write(">>");
                        Console.WriteLine(MenuText[c]);
                    }
                    else
                    {
                        Console.WriteLine(MenuText[c]);
                    }
                }
                Console.Write("\nSelect and press {Enter}\n");

                key = Console.ReadKey(true);

                if (key.Key.ToString() == "DownArrow")
                {
                    curItem++;
                    if (curItem > MenuText.Length - 1) curItem = 0;
                }
                else
                {
                    if (key.Key.ToString() == "UpArrow")
                    {
                        curItem--;
                        if (curItem < 0) curItem = Convert.ToInt16(MenuText.Length - 1);
                    }
                }
            } while (key.KeyChar != 13);

            return curItem;

        }

       


    }
}
