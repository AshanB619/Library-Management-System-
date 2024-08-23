using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace ConsoleApp1
{
    class Program{
        static void Main(string[] args){
            Addbook();
        }

        public static void Addbook(){
            Library l1=new Library();
            Console.WriteLine("Enter book Nmae");
            string Bookname=Console.ReadLine(); 
            Console.WriteLine("Enter Author");
            string Authorname=Console.ReadLine();
            Console.WriteLine("Enter ISBN number");
            int ISBNnumber=int.Parse(Console.ReadLine());
            List<object>addlist=new List<object>();
            l1.Add(Bookname,Authorname,ISBNnumber,addlist);

        }
    }
}
