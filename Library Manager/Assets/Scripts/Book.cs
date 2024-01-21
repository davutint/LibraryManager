using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Book", menuName = "Library/Book")]
public class Book : ScriptableObject
{
    public string Title;
    public string Author;
    public int ISBN;
    public int TotalCopies;
    public int BorrowedCopies;
    public int index;
    public bool veriaktarıldı = false;


    public static class DataBase
    {
        static List<Book> Books = null;
        public static List<Book> GetBooks()
        {
            if (Books != null) return Books;
            Books = Resources.LoadAll<Book>("ScriptableObjects").ToList();
            return Books;
        }

        public static Book GetBookByName(string bookName)
            => GetBooks().Find(item => item.Title == bookName);
      
    }

}
