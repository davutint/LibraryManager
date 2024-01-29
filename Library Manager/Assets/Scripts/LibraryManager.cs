using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class LibraryManager : MonoBehaviour
{
    public GameObject BookPrefab;
    public RectTransform ContantArea;
    [SerializeField]List<Book> Books;
    public GameObject HataMesaji;
    public TMP_InputField ara;
    public static LibraryManager instance;
    public GameObject TümKitaplarText;
    public GameObject OduncKitaplarText;

    private void Awake()
    {
        instance = this;
        veriSıfırla();
    }

    void veriSıfırla()
    {
        Books = Book.DataBase.GetBooks();
        foreach (var book in Books)
        {
            book.veriaktarıldı = false;
        }
    }
    private void Start()
    {
        //CreateBook();
        Guncelle();


    }
    public void TumunuGetir()
    {
        Books = Book.DataBase.GetBooks();
        TümKitaplarText.SetActive(true);
        OduncKitaplarText.SetActive(false);
        List<GameObject> OduncAlınmayanlar = new List<GameObject>();

        foreach (var book in Books)
        {

            OduncAlınmayanlar.Add(book.KitapContainer);
            Debug.Log(book.name);
            ShowFilteredBooks(OduncAlınmayanlar);

        }
    }
    public void OduncAlınanlarıGetır()
    {
        Books = Book.DataBase.GetBooks();
        TümKitaplarText.SetActive(false);
        OduncKitaplarText.SetActive(true);
        List<GameObject> OduncAlınmayanlar = new List<GameObject>();
       
        foreach (var book in Books)
        {
          
            if (book.OduncAlındı != true)
            {

                OduncAlınmayanlar.Add(book.KitapContainer);
                Debug.Log(book.name);
                HideFilteredBooks(OduncAlınmayanlar);

            }
           
        }
    }

    public void Guncelle()
    {
        Books= Book.DataBase.GetBooks();

        foreach (var book in Books)
        {
            if (book.veriaktarıldı==false)
            {
                GameObject temp = Instantiate(BookPrefab, ContantArea.position, Quaternion.identity);
                temp.GetComponent<RectTransform>().SetParent(ContantArea, false);
                temp.GetComponent<ContentScript>().VeriAl(book);
            }
            else
            {
                Debug.Log(book.name);
                
            }
            

        }
    }

    public void Kitapekle(Book book)
    {
        Books.Add(book);
        Guncelle();
    }
   

    public void SearchBooks(string searchText)
   {
        List<Book> tümKitaplar = Book.DataBase.GetBooks();
        List<GameObject> containerObjler = new List<GameObject>();
        foreach (Book book in tümKitaplar)
        {

            if (!book.Title.ToLower().Contains(searchText.ToLower())&&!book.Author.ToLower().Contains(searchText.ToLower()))
            {
                containerObjler.Add(book.KitapContainer);
                HideFilteredBooks(containerObjler);
               
            }
            else
            {
                book.KitapContainer.SetActive(true);
               
            }

            
        }
       
        
   }

    public void KitaplarıAc()
    {
        List<Book> tümKitaplar = Book.DataBase.GetBooks();
        List<GameObject> containerObjler = new List<GameObject>();

        foreach (var book in tümKitaplar)
        {
            containerObjler.Add(book.KitapContainer);

            foreach (var container in containerObjler)
            {
                container.SetActive(true);
            }
        }
    }

    public void HideFilteredBooks(List<GameObject> filteredBooks)
    {
        // Sonuçları ekrana yazdır veya başka bir işlem yap
        foreach (var book in filteredBooks)
        {
            book.SetActive(false);
        }
    }

    public void ShowFilteredBooks(List<GameObject> filteredBooks)
    {
        // Sonuçları ekrana yazdır veya başka bir işlem yap
        foreach (var book in filteredBooks)
        {
            book.SetActive(true);
        }
    }

}
