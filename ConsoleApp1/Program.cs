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
            string bookType=GetType(library);

            Book book=new Book(bookName,authorNmae,isbnNumber,bookType);
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

        public static string GetType(Library library){
            while(true){
                try{
                    Console.WriteLine("1)Fiction");
                    Console.WriteLine("2)Biography");
                    Console.WriteLine("3)History");
                    Console.WriteLine("4)Technology");
                    Console.WriteLine("5)Social Sciences");
                    Console.WriteLine("6)Humanities");
                    Console.WriteLine("7)Encyclopedias");
                    Console.WriteLine("8)Atlases");
                    Console.WriteLine("Enter Type of Book:");
                    int booktype =int.Parse(Console.ReadLine());
                    if(library.getbooktype(booktype)!="-1"){
                        return library.getbooktype(booktype);
                    }
                }catch(FormatException){
                    Console.WriteLine("Error| you can enter only numbers");
                }


            }
        }

       
        
    }
}
