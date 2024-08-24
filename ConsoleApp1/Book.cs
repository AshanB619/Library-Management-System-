using System;

namespace ConsoleApp1{

    class Book{

        public string BookName{get;set;}
        public string AuthorName{get;set;}
        public long ISBNnumber{get;set;}
        public string BookType{get;set;}

        public Book(string bookName,string authorName,long isbnNumber,string bookType){
            BookName=bookName;
            AuthorName=authorName;
            ISBNnumber=isbnNumber;
            BookType=bookType;
        }
    }
}