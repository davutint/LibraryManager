using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class BookButton : MonoBehaviour
{
   
        public TextMeshProUGUI titleText;
        public TextMeshProUGUI authorText;
        public TextMeshProUGUI statusText; // Ödünç alındı durumu için
        public Button borrowButton;

        private Book associatedBook;

        public void SetBookInfo(Book book)
        {
            associatedBook = book;

            // TextMeshPros ve diğer bilgileri ayarla
            titleText.text = $"Title: {book.Title}";
            authorText.text = $"Author: {book.Author}";
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
