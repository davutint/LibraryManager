using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.Events;

public class LibraryManager : MonoBehaviour
{
    public GameObject BookPrefab;
    public RectTransform ContantArea;
    List<Book> Books;
    


    private void Start()
    {
        CreateBook();
        
    }
    public void CreateBook()
    {
        Books = Book.DataBase.GetBooks();

        for (int i = 0; i < Books.Count; i++)
        {
            GameObject temp = Instantiate(BookPrefab, ContantArea.position, Quaternion.identity);


            temp.GetComponent<RectTransform>().SetParent(ContantArea, false);
            for (int y = 0; y < Books.Count; y++)
            {
                temp.GetComponent<ContentScript>().VeriAl(Books[i]);
                
            }

        }

    }


    void BorrowBook(int isbn)
    {
        Book book = FindBookByISBN(isbn);
        if (book != null)
        {
            book.BorrowBook();
        }
        else
        {
            Debug.LogError("Book not found.");
        }
    }

    void ReturnBook(int isbn)
    {
        Book book = FindBookByISBN(isbn);
        if (book != null)
        {
            book.ReturnBook();
        }
        else
        {
            Debug.LogError("Book not found.");
        }
    }

    Book FindBookByISBN(int isbn)
    {
        return Books.Find(b => b.ISBN == isbn);
    }

    Book CreateBook(string title, string author, int isbn, int totalCopies)
    {
        // ScriptableObject'den bir instance oluştur
        Book newBook = ScriptableObject.CreateInstance<Book>();

        // Kitap özelliklerini ayarla
        newBook.Title = title;
        newBook.Author = author;
        newBook.ISBN = isbn;
        newBook.TotalCopies = totalCopies;
        newBook.BorrowedCopies = 0;

        // UnityEvent'leri başlat
        newBook.OnBorrow = new UnityEvent();
        newBook.OnReturn = new UnityEvent();

        return newBook;
    }




}
