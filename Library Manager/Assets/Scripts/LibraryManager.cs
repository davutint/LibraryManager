using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LibraryManager : MonoBehaviour
{
    public Book[] books;
    public ScrollRect scrollRect;
    public RectTransform contentPrefab;

    public static LibraryManager instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        DisplayAllBooks();
    }

    void DisplayAllBooks()
    {
        
         AddContent();
    }
    void AddContent()
    {

        for (int i = 0; i <books.Length; i++)
        {
            // Prefab'ı kopyala
            RectTransform newContentItem = Instantiate(contentPrefab, contentPrefab.position, Quaternion.identity);
            newContentItem.SetParent(scrollRect.content, false);

            // İçerik öğesine bir metin ekleyin
          

            // Yerleşim pozisyonunu ayarla (alt alta)
            float height = newContentItem.rect.height;
            float spacing = 10f; // İstediğiniz boşluk miktarını ayarlayın
            float newY = -i * (height + spacing);
            newContentItem.anchoredPosition = new Vector2(0f, newY);
        }

    }
    



}
