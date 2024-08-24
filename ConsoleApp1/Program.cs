using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library=new Library();
            string bookName=GetBookName();
            string authorNmae=GetAuthorName(library);
            int isbnNumber=Getisbnnumber();

            Book book=new Book(bookName,authorNmae,isbnNumber);
            library.AddBook(book);

        }

        public static string GetBookName(){
            Console.WriteLine("enter book name");
            return Console.ReadLine();
        }
        public static string GetAuthorName(Library library){
            while(true){
                Console.WriteLine("Enter author name:");
                string authorName = Console.ReadLine();

                if(library.checkAuthorname(authorName)){
                    return authorName;
                }else{
                    Console.WriteLine("Error|Author Name can have only letters");

                }
            }
        }
        public static int Getisbnnumber(){
            while(true){
                try{
                    Console.WriteLine("Enter ISBN number");
                    return int.Parse(Console.ReadLine());

                }catch(FormatException){
                    Console.WriteLine("Error|Isbn number should have numbers only");

                }
            }
        }

       
        
    }
}
