using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace ConsoleApp1{
    class Library{
        public string Bookname{get;set;}
        public string Authorname{get;set;}
        public int ISBNnumber{get;set;}
        public void Add(string Bookname,string Authorname,int ISBNnumber,List<object>Addlist){
            Addlist.Add(Bookname);
            Addlist.Add(Authorname);
            Addlist.Add(ISBNnumber);
            foreach(object item in Addlist){
                Console.WriteLine(item);
            }
        }
    }
}