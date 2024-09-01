using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            library.readfiledata();

            //Book Book1 = GetBookDetails(library);
            //library.AddBook(Book1);
            //library.Savetofile(Book1);
            //library.display();

            Editbookdetails(library);

            

        }

        public static Book GetBookDetails(Library library)
        {
            string GetBookName()
            {
                Console.WriteLine("Enter book name:");
                return Console.ReadLine();
            }

            string GetAuthorName()
            {
                while (true)
                {
                    Console.WriteLine("Enter author name:");
                    string authorName = Console.ReadLine();

                    if (library.checkAuthorname(authorName))
                    {
                        return authorName;
                    }
                    else
                    {
                        Console.WriteLine("Error | Author Name can have only letters");
                    }
                }
            }

            long GetIsbnNumber()
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Enter ISBN number:");
                        long isbnNumber = long.Parse(Console.ReadLine());
                        if (library.checkisbnnumber(isbnNumber))
                        {
                            return isbnNumber;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error | ISBN number should have numbers only");
                    }
                }
            }

            string GetType()
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("1) Fiction");
                        Console.WriteLine("2) Biography");
                        Console.WriteLine("3) History");
                        Console.WriteLine("4) Technology");
                        Console.WriteLine("5) Social Sciences");
                        Console.WriteLine("6) Humanities");
                        Console.WriteLine("7) Encyclopedias");
                        Console.WriteLine("8) Atlases");
                        Console.WriteLine("Enter Type of Book:");
                        int booktype = int.Parse(Console.ReadLine());
                        string bookType = library.getbooktype(booktype);

                        if (bookType != "-1")
                        {
                            return bookType;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error | You can enter only numbers");
                    }
                }
            }

            string bookName = GetBookName();
            string authorName = GetAuthorName();
            long isbnNumber = GetIsbnNumber();
            string bookType = GetType();

            return new Book(bookName, authorName, isbnNumber, bookType);
        }

        public static void Editbookdetails(Library library){
            long check_isbnnumber_exsist(){
                while(true){
                    try{
                        Console.WriteLine("Enter ISBN number");
                        long ISBNnumber=long.Parse(Console.ReadLine());
                        if(library.isisbnexists(ISBNnumber)){
                            return ISBNnumber;
                        }else{
                            Console.WriteLine("Error | ISBN number not found");
                        }
                    }catch(FormatException e){
                        Console.WriteLine("Error | ISBN number should be only numbers.");
                    }
                }
            }

            long isbnNumber=check_isbnnumber_exsist();
            Book book=library.getdetailsbyisbn(isbnNumber);
            Console.WriteLine($"1)Book Name-{book.BookName}\n2)Author Name-{book.AuthorName}\n3)ISBN Number-{book.ISBNnumber}\n4)Book Type-{book.BookType}");
        }
        

    }
}
