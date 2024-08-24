using System;

namespace ConsoleApp1{

    class Book{

        public string BookName{get;set;}
        public string AuthorName{get;set;}
        public int ISBNnumber{get;set;}

        public Book(string bookName,string authorName,int isbnNumber){
            BookName=bookName;
            AuthorName=authorName;
            ISBNnumber=isbnNumber;
        }
    }
}