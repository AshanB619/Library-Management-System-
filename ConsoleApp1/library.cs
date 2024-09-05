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
        public void display(){
            foreach(var inner in books){
                foreach(var inner1 in inner){
                    Console.WriteLine($"Book Name: {inner1.BookName}, Author Name: {inner1.AuthorName}, ISBN Number: {inner1.ISBNnumber}, Book Type: {inner1.BookType}");
                }
            }
        }
        public bool checkAuthorname(string authorName){
            return authorName.All(char.IsLetter);
        }

        public bool checkisbnnumber(long isbnNumber){
            if(isbnNumber.ToString().Length!=13){
                Console.WriteLine("Error | You can have only 13 digits for ISBN number.");
                return false;
            }
            foreach(var booklist in books){
                foreach(var book in booklist){
                    if(book.ISBNnumber==isbnNumber){
                        Console.WriteLine("Error | ISBN number should be identical.");
                        return false;
                    }
                }
            }
            return true;
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
                         writercfile.WriteLine($"{subbook.BookName},{subbook.AuthorName},{subbook.ISBNnumber},{subbook.BookType}");
                       }
                    }
                }
            }catch(Exception e){
                Console.WriteLine("Error when writing on file");
            }
        }

        public void readfiledata(){
            try{
                using(StreamReader readfile=new StreamReader(Filepath)){
                    string line;
                    while((line=readfile.ReadLine())!=null){
                        string[] data=line.Split(',');
                        Book book1=new Book(data[0],data[1],long.Parse(data[2]),data[3]);
                        List<Book>subbooks=new List<Book>();   
                        subbooks.Add(book1);
                        books.Add(subbooks);                    
                    }
                }
            }catch(Exception e){
                Console.WriteLine("error when reading file");
            }
        }

        public bool displaydetails(Book book){
            foreach(var inner in books){
                 foreach(var inner1 in inner){
                    if(inner1.ISBNnumber==book.ISBNnumber){
                        Console.WriteLine($"Book Name: {inner1.BookName}, Author Name: {inner1.AuthorName}, ISBN Number: {inner1.ISBNnumber}, Book Type: {inner1.BookType}");
                        return true;
                    }
                 }
            }
            return false;       
        }

        public bool isisbnexists(long isbnNumber){
            foreach(var booklist in books ){
                foreach(var book in booklist){
                    if(book.ISBNnumber==isbnNumber){
                        return true;
                    }
                }
            }
            return false;
        }

        public Book getdetailsbyisbn(long isbnNumber){
            foreach(var booklist in books){
                foreach(var book in booklist){
                    if(book.ISBNnumber==isbnNumber){
                        return book;
                    }
                }
            }
            return null;
        }

        public void Editnameofbook(long isbnNumber,string newbookname,string newAuthorname,string newBooktype){
            foreach(var booklist in books){
                foreach(var book in booklist){
                    if(book.ISBNnumber==isbnNumber){
                        book.BookName=newbookname;
                        book.AuthorName=newAuthorname;
                        book.BookType=newBooktype;
                        return;
                    }
                }
            }
            
        }

        public Book searchbookall(string booktype){
            foreach(var booklist in books){
                foreach(var book in booklist){
                    if(book.BookType==booktype){
                        return book;
                    }
                }
            }
            return null;
        }

        

    }
}