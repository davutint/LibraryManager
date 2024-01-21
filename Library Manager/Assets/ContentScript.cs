using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ContentScript : MonoBehaviour
{
    public TextMeshProUGUI KitapAdı;
    public TextMeshProUGUI KitapYazarı;
    public TextMeshProUGUI KitapSayısı;
    public TextMeshProUGUI OduncSayısı;
    public TextMeshProUGUI statusText; // Ödünç alındı durumu için

    public Button borrowButton;


    public void VeriAl(Book bookdata)
    {
        KitapAdı.SetText(bookdata.Title);
        KitapYazarı.SetText(bookdata.Author);
        KitapSayısı.SetText(bookdata.TotalCopies.ToString());
        OduncSayısı.SetText(bookdata.BorrowedCopies.ToString());
        
        SetBookInfo(bookdata);
    }

   
    private Book associatedBook;

    public void SetBookInfo(Book book)
    {
        associatedBook = book;

        // TextMeshPros ve diğer bilgileri ayarla
        KitapAdı.text = $"Title: {book.Title}";
        KitapYazarı.text = $"Author: {book.Author}";
        UpdateStatusText();

        // Button'a tıklama olayına abone ol
        borrowButton.onClick.AddListener(BorrowOrReturnBook);
    }
    void BorrowOrReturnBook()
    {
        if (associatedBook != null)
        {
            if (associatedBook.IsBorrowed)
            {
                associatedBook.ReturnBook();
            }
            else
            {
                associatedBook.BorrowBook();
            }

            UpdateStatusText();
        }
    }

    void UpdateStatusText()
    {
        // Ödünç alındı durumunu güncelle
        statusText.text = associatedBook.IsBorrowed ? "Borrowed" : "Available";
    }


}
