using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;

public class CreateBook : MonoBehaviour
{
    public TMP_InputField Title;
    [SerializeField] TMP_InputField Author;
    [SerializeField] TMP_InputField ISBN;
    public GameObject KitapHatası;
    public GameObject ISBNHatası;
    public GameObject GerekliBilgiHatası;
    public Button KitapEkleButton;
    public void createBook()
    {
        if (Title.text!="" && Author.text!="" && ISBN.text!="")
        {     
            KitapOlustur(Title, Author, ISBN);
        }
        else
            GerekliBilgiHatası.SetActive(true);
       
    }

    public void NameCheck(string title)
    {
        if (IsNameExist(title))
        {
            KitapHatası.SetActive(true);
            KitapEkleButton.enabled = false;
            KitapEkleButton.GetComponent<Image>().color = Color.red;

        }
        else
        {
            KitapHatası.SetActive(false);
            KitapEkleButton.enabled = true;
            KitapEkleButton.GetComponent<Image>().color = Color.white;
        }
    }

    public void ISBNCheck(string ISBN)
    {
        Debug.Log("ISBN== "+ISBN);
        
            if (IsISBNExist(ISBN))
            {
                ISBNHatası.SetActive(true);
                KitapEkleButton.enabled = false;
                KitapEkleButton.GetComponent<Image>().color = Color.red;

            }
            else
            {
                ISBNHatası.SetActive(false);
                KitapEkleButton.enabled = true;
                KitapEkleButton.GetComponent<Image>().color = Color.white;
            }
        
        
    }


    bool IsISBNExist(string isbn)
    {
       
        int temp;
        Book[] existingBooks = Resources.LoadAll<Book>("ScriptableObjects");
        int.TryParse(isbn, out temp);
        Debug.Log("TEMP:  "+temp);

        foreach (var book in existingBooks)
        {
            if (book.ISBN == temp)
            {
                return true;
            }
        }
        return false;
        
    }


    bool IsNameExist(string title)
    {
        Book[] existingBooks = Resources.LoadAll<Book>("ScriptableObjects");
        foreach (var book in existingBooks)
        {
            if (book.Title.ToLower() == title.ToLower())
            {
                return true;
            }
        }
        return false;
    }

    
    public void Reflesh()
    {
        LibraryManager.instance.Guncelle();
    }

   

    bool IsBookAlreadyExists(int isbn, string title)
    {
        Book[] existingBooks = Resources.LoadAll<Book>("ScriptableObjects");
        foreach (var book in existingBooks)
        {
            if (book.ISBN == isbn || book.Title == title)
            {
                return true;
            }
        }
        return false;
    }

    Book KitapOlustur(TMP_InputField title, TMP_InputField author, TMP_InputField isbn)
    {
        // ScriptableObject'den bir instance oluştur
        Book newBook = ScriptableObject.CreateInstance<Book>();

        // Kitap özelliklerini ayarla

        newBook.Title = title.text;
        newBook.ISBN = int.Parse(isbn.text);
        newBook.Author = author.text;
        
        
        newBook.BorrowedCopies = 0;
        newBook.TotalCopies=1;
        // UnityEvent'leri başlat
        UnityEditor.AssetDatabase.CreateAsset(newBook, "Assets/Resources/ScriptableObjects/" + title.text + ".asset");
        UnityEditor.AssetDatabase.SaveAssets();
        LibraryManager.instance.Kitapekle(newBook);

        return newBook;
    }
}
