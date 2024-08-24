using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Net.Security;
using System.Web;
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

    }
}