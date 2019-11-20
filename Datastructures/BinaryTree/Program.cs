using System;
using BinaryTreeApp.models;

namespace BinaryTreeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTreeItem item = new BinaryTreeItem(null, null, null);
            Console.WriteLine(item);

            Console.ReadKey();
        }
    }
}