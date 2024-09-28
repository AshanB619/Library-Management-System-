using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true){
                Library library = new Library();
                Console.WriteLine("Enter Number:\n1) To Add Book\n2) To Edit Book\n3) To Display Summary\n4) To Delete Book\n5) To Search Book\n6) Exit");
                string choice =Console.ReadLine();
                switch(choice){
                    case "1":
                      Book Book1 = GetBookDetails(library);
                      library.AddBook(Book1);
                      library.Savetofile(Book1);
                      break;
                    case "2":
                      Book Book2 = GetBookDetails(library);
                      Editbookdetails(library);
                      library.Savetofile(Book2);
                      break;
                    case "3":
                      ShowbooksAll(library);
                      break;
                    case "4":
                      Book Book3 = GetBookDetails(library);
                      Deletebook(library);
                      library.Savetofile(Book3);
                      break;
                    case "5":
                      Searchbook(library);
                      break;
                    case "6":
                      return;
                    default:
                      Console.WriteLine("Invalid choice Enter value between 1-6");
                      continue;
                    
                }

            }
            //Library library = new Library();
            //library.readfiledata();
           // Book Book1 = GetBookDetails(library);
            //library.AddBook(Book1);
            //library.Savetofile(Book1);

           // Editbookdetails(library);
            //ShowbooksAll(library);
            //Deletebook(library);
            //library.display();
           // Searchbook(library);

            

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

            void editdetails(int choise_edit,Book book){
                switch(choise_edit){
                    case 1:
                        Console.WriteLine("Enter new book name:");
                        string newbookname=Console.ReadLine();
                        library.Editnameofbook(book.ISBNnumber,newbookname,book.AuthorName,book.BookType);
                        break;
                    case 2:
                        while(true){
                            Console.WriteLine("Enter New Author name:");
                            string newAuthorname=Console.ReadLine();
                            if(library.checkAuthorname(newAuthorname)){
                                library.Editnameofbook(book.ISBNnumber,book.BookName,newAuthorname,book.BookType);
                                break;
                            }else{
                                Console.WriteLine("Error | Author Name can have only letters");
                                continue;
                            }
                        }
                        
                        break;
                    case 3:
                        while(true){
                            try{
                                Console.WriteLine("1) Fiction");
                                Console.WriteLine("2) Biography");
                                Console.WriteLine("3) History");
                                Console.WriteLine("4) Technology");
                                Console.WriteLine("5) Social Sciences");
                                Console.WriteLine("6) Humanities");
                                Console.WriteLine("7) Encyclopedias");
                                Console.WriteLine("8) Atlases");
                                Console.WriteLine("Enter Type of Book:");
                                int newBooktypenumber=int.Parse(Console.ReadLine());
                                if(newBooktypenumber>8 || newBooktypenumber<=0){
                                    Console.WriteLine("Error | You can enter only numbers 1-8");
                                    continue;
                                }
                                string newBooktype=library.getbooktype(newBooktypenumber);
                                library.Editnameofbook(book.ISBNnumber,book.BookName,book.AuthorName,newBooktype);
                                break;
                            }catch(FormatException e){
                                Console.WriteLine("Error | You can enter only numbers");
                            }

                        }
                        break;
                    default:
                        Console.WriteLine("error");
                        break;      
                }
                
            }
            long isbnNumber=check_isbnnumber_exsist();
            Book book=library.getdetailsbyisbn(isbnNumber);
            Console.WriteLine($"1)Book Name-{book.BookName}\n2)Author Nmae-{book.AuthorName}\n3)Book Type-{book.BookType}");
            while(true){
                try{
                    Console.WriteLine("Enter number you need to change");
                    int choise_edit=int.Parse(Console.ReadLine());
                    if(choise_edit>3 || choise_edit<=0){
                        Console.WriteLine("Error | you can enter number between 1-4");
                        continue;
                    }
                    editdetails(choise_edit,book);
                    break;

                }catch(FormatException e){
                    Console.WriteLine("Error | You can enter only numbers.");
            }
            }
            library.Savetofile(book);
        }

        public static void ShowbooksAll(Library library){
            while(true){
                try{
                    Console.WriteLine("1) Fiction");
                    Console.WriteLine("2) Biography");
                    Console.WriteLine("3) History");
                    Console.WriteLine("4) Technology");
                    Console.WriteLine("5) Social Sciences");
                    Console.WriteLine("6) Humanities");
                    Console.WriteLine("7) Encyclopedias");
                    Console.WriteLine("8) Atlases");
                    Console.WriteLine("Enter Type of Book:");
                    int Booktypenumber=int.Parse(Console.ReadLine());
                    if(Booktypenumber>8 || Booktypenumber<=0){
                        Console.WriteLine("Error | You can enter only numbers 1-8");
                        continue;
                    }
                    string bookType=library.getbooktype(Booktypenumber);
                    library.searchbookall(bookType);
                    break;
                }catch(FormatException e){
                    Console.WriteLine("Error | You can enter only numbers");
                }
            }
        }

        public static void Deletebook(Library library){
            while (true)
            {
                try{
                    Console.WriteLine("Enter ISBN number:");
                    long isbnNumber = long.Parse(Console.ReadLine());
                    if(library.isisbnexists(isbnNumber)){
                        library.Deletebook(isbnNumber);
                    }else{
                        Console.WriteLine("Error | ISBN number not found");
                        continue;
                    }
                    break;

                }catch(FormatException e){
                    Console.WriteLine("Error | ISBN number should have numbers only");
                }
            }
        }
        public  static void Searchbook(Library library){
            while(true){
                try{
                    Console.WriteLine("Enter Book Name To Find:");
                    string bookName=Console.ReadLine();
                    library.Searchbook(bookName);
                    break;                   
                }catch(FormatException e){
                    Console.WriteLine("Not Valid input");
                }
            }
        }
        
        
        

    }
}
