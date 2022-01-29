using BLL.Managers.Interfaces;
using BLL.Services.Classes;
using BLL.Services.Interfaces;
using Domain.Models;
using System;

namespace ComicsShop
{
    class Program
    {
        public static readonly ITagService tagService;
        public static readonly IAuthorServise authorService;
        public static readonly IComicsService comicsService;
        public static bool Work = true;
        static Program()
        {
            tagService = new TagService();
            authorService = new AuthorService(); 
            comicsService = new ComicsService();
        }

        static void Main(string[] args)
        {
            //Console.WriteLine(GetSpecialTags("Marvel").Name);
            do
            {
                MethodController.FirstMenu();
            } while (Work);
            Console.ReadKey();
        }

        static Tag GetSpecialTags(string name)
        {
            return tagService.GetTagByName(name);
        } 
    }
}
