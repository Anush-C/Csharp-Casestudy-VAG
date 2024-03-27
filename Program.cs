using CaseStudy.Exceptions;
using CaseStudy.MainMenu;
using CaseStudy.Models;
using CaseStudy.Repositories;
using System;

namespace CaseStudy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Virtual Art Gallery";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("            WELCOME TO VIRTUAL ART GALLERY            ");
            Console.WriteLine("-------------------------------------------------\n");
            Console.ResetColor();

            VirtualArtGallery artGallery = new VirtualArtGallery();
            artGallery.Handlemenu();

            Console.WriteLine("\nThank you for visiting! Press any key to exit.");
            Console.ReadKey(true);
        }
    }
}
