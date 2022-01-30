using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicsShop
{
    public static class TagHelper
    {
        #region Add
        public static void AddTag()
        {
            Tag tag = new Tag();
            Console.Write("Enter TagName: ");
            tag.Name = Console.ReadLine();
            Program.tagService.AddTag(tag);
        }
        #endregion
        public static void ShowAll()
        {
            var tags = Program.tagService.GetAll();
            short curentItem = 0;

            curentItem = MethodController.Menu(curentItem, tags.Select(t => t.Name).ToArray());

            var tag = tags[curentItem];
            TagMenu(tag);
        }

        static public void TagMenu(Tag tag)
        {
            short curItem = 0;
            string[] menuSelect = { "Edit name", "Delete tag","Type of find tag","Return to tags menu", "Return to main menu", };

            switch (MethodController.Menu(curItem, menuSelect,$"Menu for tag: {tag.Name}"))
            {
                case 0: EditTag(tag); break;
                case 1: Program.tagService.DeleteTag(tag); break;
                case 2: FindTagMenu(); break;
                case 3: MethodController.TagsMenu(); break;
                case 4: MethodController.FirstMenu(); break;
            }
        }

        static public void EditTag(Tag tag)
        {
            Console.WriteLine("Enter new tag");
            tag.Name = Console.ReadLine();

            Program.tagService.UpdateTag(tag);
            TagMenu(tag);
        }
        #region Find
        static public void FindTagMenu()
        {
            short curItem = 0;
            string[] menuSelect = { "Find part of name", "Find by name", "Find by Id ","Return to tags menu", "Return to main menu", };

            switch (MethodController.Menu(curItem, menuSelect, $"Menu"))
            {
                case 0: FindPartName(); break;
                case 1: FindOfName(); break;
                case 2: FindById(); break;
                case 3: MethodController.TagsMenu(); break;
                case 4: MethodController.FirstMenu(); break;
            }
        }

        static public void FindPartName()
        {
            Console.WriteLine("Enter the name you want to find");
            var findName = Console.ReadLine();

            var t = Program.tagService.FindPartName(findName);
            Console.WriteLine(t.Name);
            FindTagMenu();
        }

        static public void FindOfName()
        {
            Console.WriteLine("Enter the name you want to find");
            var findName = Console.ReadLine();

            var t = Program.tagService.GetByName(findName);
            Console.WriteLine(t.Name);

            FindTagMenu();
        }
        static public void FindById()
        {
            Console.WriteLine("Enter the name you want to find");
            Guid findId = Guid.Parse(Console.ReadLine());

           var t = Program.tagService.GetById(findId);
            Console.WriteLine(t.Name);
            FindTagMenu();
        }
        #endregion
    }
}
