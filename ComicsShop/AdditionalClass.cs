using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicsShop
{
    public class AdditionalClass
    {
        static public void FirstMenu()
        {
            short curItem = 0;
            string[] menuItems= new string [3];

            switch (Menu(curItem, menuItems))
            {
                case 0: ; break;
                case 1: ; break;
                case 2: ; break;
                case 3: ; break;
                case 4: FirstMenu(); break;
                case 5: Program.Work = false; return;
            }
        }
        static public short Menu(short curItem, string[] MenuText)
        {
            ConsoleKeyInfo key;
            short c;
            do
            {
                Console.Clear();
                Console.WriteLine("[ MENU ]");

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
                Console.Write("\nSelect and press {Enter}");

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

        protected void AddElements()
        {

        }
    }
}
