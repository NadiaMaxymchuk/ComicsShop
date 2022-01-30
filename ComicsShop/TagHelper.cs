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
        public static void AddTag()
        {
            Tag tag = new Tag();
            Console.Write("Enter TagName: ");
            tag.Name = Console.ReadLine();
            Program.tagService.AddTag(tag);
        }

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
            string[] menuSelect = { "Edit name", "Delete tag","Return to tags menu", "Return to main menu", };

            switch (MethodController.Menu(curItem, menuSelect,$"Menu for tag: {tag.Name}"))
            {
                case 0: EditTag(tag); break;
                case 1: Program.tagService.DeleteTag(tag); break;
                case 2: MethodController.TagsMenu(); break;
                case 3: MethodController.FirstMenu(); break;
            }
        }

        static public void EditTag(Tag tag)
        {
            Console.WriteLine("Enter new tag");
            tag.Name = Console.ReadLine();

            Program.tagService.UpdateTag(tag);
            TagMenu(tag);
        }
    }
}
