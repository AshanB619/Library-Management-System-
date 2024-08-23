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
            string Bname=Console.ReadLine();
            l1.Bookname=Bname;
        }
    }
}
