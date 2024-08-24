using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
namespace ConsoleApp1{
    class Library{
        private List<Book> books=new List<Book>();

        public void AddBook(Book book){
            books.Add(book);
        }
        public bool checkAuthorname(string authorName){
            return authorName.All(char.IsLetter);
        }

        public bool checkisbnnumber(long isbnNumber){
            long isbncount=isbnNumber.ToString().Length;
            if(isbncount==13){
                return true;
            }
            Console.WriteLine("Error|you can have only 13 digits for ISBN number");
            return false;
        }

    }
}