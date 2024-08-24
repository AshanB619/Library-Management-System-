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
            long isbnNumber=Getisbnnumber(library);

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
        public static long Getisbnnumber(Library library){
            while(true){
                try{
                    Console.WriteLine("Enter ISBN number");
                    long isbnNumber=long.Parse(Console.ReadLine());
                    if(library.checkisbnnumber(isbnNumber)){
                        return isbnNumber;
                    }

                }catch(FormatException){
                    Console.WriteLine("Error|Isbn number should have numbers only");

                }
            }
        }

       
        
    }
}
