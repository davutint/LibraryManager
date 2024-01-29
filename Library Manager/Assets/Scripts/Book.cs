using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using System;

[CreateAssetMenu(fileName = "New Book", menuName = "Book")]
public class Book : ScriptableObject
{
    public string Title;
    public string Author;
    public int ISBN;
    public int TotalCopies;
    public int BorrowedCopies;
    public GameObject KitapContainer;
    public GameObject TeslimZamanıObj;
    public bool veriaktarıldı = false;
    public bool OduncAlındı = false;
    public DateTime borrowTime = DateTime.Now;
    
    
    public void BorrowBook()
    {
        if (BorrowedCopies < TotalCopies&&OduncAlındı==false)
        {
            BorrowedCopies++;
            TotalCopies--;
           
            OduncAlındı = true;
            borrowTime = DateTime.Now;
            Debug.Log(borrowTime.ToString());
            
        }
        else
        {
            Debug.Log("Bu kitaptan zaten elinde var ");
        }
    }

    public bool ZamanAsımıOldu()
    {
        DateTime teslim = DateTime.Now;
        DateTime oduncalma = borrowTime.AddDays(7);
        int olc = DateTime.Compare(teslim, oduncalma);
        if (olc < 0)
        {
            return false;
        }
        return true;
    }

    public string KalanZamanDondur()
    {
        if (OduncAlındı)
        {
            DateTime k = borrowTime.AddDays(7);
            return k.ToString();
        }
        return null;
    }

   

    public void ReturnBook()
    {
        if (BorrowedCopies > 0)
        {
            DateTime teslim = DateTime.Now;
            DateTime oduncalma = borrowTime.AddDays(7);
            int olc = DateTime.Compare(teslim, oduncalma);
            if (olc<0)
            {
               
                BorrowedCopies--;
                TotalCopies++;
                Debug.Log($"Book {Title} returned successfully. Remaining copies: {TotalCopies - BorrowedCopies}");
                OduncAlındı = false;
                Debug.Log(oduncalma);
                Debug.Log(olc);
                Debug.Log(teslim);

            }
            else
            {
                Debug.Log("ZAMAN AŞIMI!!");
                Debug.Log(borrowTime);
                Debug.Log(olc);
                Debug.Log(oduncalma);
                Debug.Log(teslim);
            }

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

       
    }


    

}
