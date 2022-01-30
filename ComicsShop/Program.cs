using BLL.Managers.Interfaces;
using BLL.Services.Classes;
using Domain.Models;
using System;

namespace ComicsShop
{
    class Program
    {
        static readonly ITagService tagService;
        public static bool Work = true;
        static Program()
        {
            tagService = new TagService();
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetSpecialTags("Marvel").Name);
            do
            {
              //  AdditionalClass.FirstMenu();
            } while (Work);
            Console.ReadKey();
        }

        static Tag GetSpecialTags(string name)
        {
            return tagService.GetTagByName(name);
        } 
    }
}
