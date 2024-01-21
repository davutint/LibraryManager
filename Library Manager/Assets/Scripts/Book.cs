using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Book", menuName = "Library/Book")]
public class Book : ScriptableObject
{
    public string Title;
    public string Author;
    public int ISBN;
    public int TotalCopies;
    public int BorrowedCopies;
    
    public bool veriaktarıldı = false;


    public UnityEvent OnBorrow;
    public UnityEvent OnReturn;

    public void BorrowBook()
    {
        if (BorrowedCopies < TotalCopies)
        {
            BorrowedCopies++;
            Debug.Log($"Book {Title} borrowed successfully. Remaining copies: {TotalCopies - BorrowedCopies}");

            // OnBorrow olayını tetikle
            OnBorrow.Invoke();
        }
        else
        {
            Debug.Log("No available copies for borrowing.");
        }
    }

    public bool IsBorrowed
    {
        get { return BorrowedCopies > 0; }
    }

    public void ReturnBook()
    {
        if (BorrowedCopies > 0)
        {
            BorrowedCopies--;
            Debug.Log($"Book {Title} returned successfully. Remaining copies: {TotalCopies - BorrowedCopies}");

            // OnReturn olayını tetikle
            OnReturn.Invoke();
        }
        else
        {
            Debug.Log("No borrowed copies to return.");
        }
    }
    public static class DataBase
    {
        static List<Book> Books = null;
        public static List<Book> GetBooks()
        {
            if (Books != null) return Books;
            Books = Resources.LoadAll<Book>("ScriptableObjects").ToList();
            return Books;
        }

        public static Book SearchBook(string keyword)
            => GetBooks().Find(item =>
            item.Title == keyword ||
            item.Author==keyword);
      
    }


    

}
