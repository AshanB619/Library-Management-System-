using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Net.Security;
using System.Web;
namespace ConsoleApp1{
    class Library{
        private List<List<Book>> books = new List<List<Book>>();
        public string Filepath=@"C:\Users\user\Desktop\myprojectc\Library-Management-System-\ctext.txt";
        public void AddBook(Book book){
            List<Book>sub_books=new List<Book>();
            sub_books.Add(book);
            books.Add(sub_books);
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
        public string getbooktype(int chechtype){
            if(chechtype==1){
                return "Fiction";
            }else if(chechtype==2){
                return "Biography";
            }else if(chechtype==3){
                return"History";
            }else if(chechtype==4){
                return"Technology";
            }else if(chechtype==5){
                return"Social Sciences";
            }else if(chechtype==6){
                return"Humanities";
            }else if(chechtype==7){
                return"Encyclopedias";
            }else if(chechtype==8){
                return"Atlases";
            }else if(chechtype==0 || chechtype>=9){
                Console.WriteLine("Error|you can enter only numbers 1-8");
            }
            return"-1";
        }

        public void Savetofile(Book book){
            try{
                using(StreamWriter writercfile=new StreamWriter(Filepath)){
                    foreach(var sublist in books){
                       foreach(var subbook in sublist){
                         writercfile.WriteLine($"{book.BookName},{book.AuthorName},{book.ISBNnumber},{book.BookType}");
                       }
                    }
                }
            }catch(Exception e){
                Console.WriteLine("Error when writing on file");
            }
        }

    }
}