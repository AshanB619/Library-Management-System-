using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
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

        public void searchbookall(string booktype){
            bool checktype = false;
            foreach (var booklist in books){
                foreach (var book in booklist){
                    if (book.BookType == booktype){
                        if (!checktype){
                            Console.WriteLine($"{"Book Name",-30} {"Author Name",-30} {"ISBN Number",-20}");
                            Console.WriteLine(new string('-', 80)); 
                            checktype = true;
                }

                Console.WriteLine($"{book.BookName,-30} {book.AuthorName,-30} {book.ISBNnumber,-20}");
              }
            }
        }

            if (!checktype){
                Console.WriteLine("No any book type found");
                
            }
        }
        public void Deletebook(long isbnNumber){
            books.RemoveAll(booklist => booklist.Any(book => book.ISBNnumber == isbnNumber));
        }
        public void Searchbook(string bookName)
        {
              bool check_bookname_is_exsist = false;

              foreach (var booklist in books)
              {
                    foreach (var book in booklist)
                    {
                          if (bookName.ToLower() == book.BookName.ToLower())
                          {
                            Console.WriteLine("Exact match found for your search:\n");
                            Console.WriteLine($"Book Name - {book.BookName}\nAuthor - {book.AuthorName}\nISBN Number - {book.ISBNnumber}\nBook Type - {book.BookType}");
                            check_bookname_is_exsist = true;
                          }
                    }
              }

              bool sub_check_bookname_is_exsist = false;
              bool similarBookPrinted = false;

              if (!check_bookname_is_exsist)
              {
                    foreach (var booklist in books)
                    {
                          foreach (var book in booklist)
                          {
                                if (book.BookName.Length >= 3 && bookName.Length >= 3)
                                {
                                      if (book.BookName.Substring(0, 3).Equals(bookName.Substring(0, 3), StringComparison.OrdinalIgnoreCase))
                                      {
                                            if (!similarBookPrinted)
                                            {
                                                Console.WriteLine("Did you mean one of these similar books?\n");
                                                Console.WriteLine($"{"Book Name",-30} {"Author Name",-30} {"ISBN Number",-30}{"Book Type",-30}");
                                                similarBookPrinted = true;
                                            }

                                            Console.WriteLine($"{book.BookName,-31}{book.AuthorName,-31}{book.ISBNnumber,-30}{book.BookType,-31}");
                                            sub_check_bookname_is_exsist = true;
                                      }
                                }
                          }
                    }
              }

              bool sub_sub_check_bookname_is_exsist = false;
              bool nearestResultPrinted = false;

              if (!sub_check_bookname_is_exsist)
              {
                    foreach (var booklist in books)
                    {
                          foreach (var book in booklist)
                          {
                                if (book.BookName.ToLower()[0] == bookName.ToLower()[0])
                                {
                                      if (!nearestResultPrinted)
                                      {
                                        Console.WriteLine("Here’s the closest match based on your input:\n");
                                        Console.WriteLine($"{"Book Name",-30} {"Author Name",-30} {"ISBN Number",-30}{"Book Type",-30}");
                                        nearestResultPrinted = true;
                                      }

                                      Console.WriteLine($"{book.BookName,-31}{book.AuthorName,-31}{book.ISBNnumber,-30}{book.BookType,-31}");
                                      sub_sub_check_bookname_is_exsist = true;
                                }
                          }
                    }
              }

              if (!sub_sub_check_bookname_is_exsist && !check_bookname_is_exsist)
              {
                    Console.WriteLine("No result found|Try again");
              }
        }


    }
}