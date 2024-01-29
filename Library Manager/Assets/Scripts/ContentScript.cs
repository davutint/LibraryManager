using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ContentScript : MonoBehaviour
{
    [Header("TEXTS")]
    public TextMeshProUGUI KitapAdı;
    public TextMeshProUGUI KitapYazarı;
    public TextMeshProUGUI KitapSayısı;
    public TextMeshProUGUI OduncSayısı;
    public TextMeshProUGUI KalanZaman;
    
    [Header("GAMEOBJECTS")]
    public GameObject TeslimZamanıObj;
    public GameObject ContentObj;
    public GameObject ZamanAsımıHatasıObj;

    [Header("BUTTONS")]
    public Button borrowButton;
    public Button AddBookButton;
    [Header("BOOK")]

    public Book AtananBook;
    [Header("INPUTFIELD")]

    public TMP_InputField EklenecekKitapAdeti;
    

    public void VeriAl(Book bookdata)
    {
        AtananBook = bookdata;
        TextUpdate(AtananBook);
        borrowButton.onClick.AddListener(() => OduncAlveyaGerıVer(bookdata));
        AddBookButton.onClick.AddListener(()=>KitapEkle(bookdata));
        bookdata.KitapContainer = ContentObj;
        bookdata.veriaktarıldı = true;
        bookdata.TeslimZamanıObj = TeslimZamanıObj;
        
        
    }

    public void KitapEkle(Book book)
    {

        book.TotalCopies += EklenecekAdet();
        KitapSayısı.SetText("Kitap Adeti: " + book.TotalCopies.ToString());
        
        
    }

    void TextUpdate(Book book)
    {
        if (book.OduncAlındı)
        {
            TeslimZamanıObj.SetActive(true);

        }
        else
            TeslimZamanıObj.SetActive(false);
        KalanZaman.text = book.KalanZamanDondur();
        KitapAdı.SetText(book.Title);
        KitapYazarı.SetText(book.Author);
        KitapSayısı.SetText("Kitap Adeti: " + book.TotalCopies.ToString());
        OduncSayısı.SetText("Ödünç Adeti: " + book.BorrowedCopies.ToString());
        if (book.OduncAlındı)
        {
            borrowButton.GetComponentInChildren<TextMeshProUGUI>().SetText("Geri Ver");
        }
        else
            borrowButton.GetComponentInChildren<TextMeshProUGUI>().SetText("Ödünç Al");
    }
    public int EklenecekAdet()
    {
        if (EklenecekKitapAdeti.text!="")
        {
            return int.Parse(EklenecekKitapAdeti.text);
        }
        return 1;
    }
    
    void OduncAlveyaGerıVer(Book book)
    {
        
        if (book.OduncAlındı)
        {
            if (book.ZamanAsımıOldu())
            {
                borrowButton.enabled = false;
                ZamanAsımıHatasıObj.SetActive(true);
            }
            else
            {
                borrowButton.enabled = true;
                ZamanAsımıHatasıObj.SetActive(false);
            }

            borrowButton.GetComponentInChildren<TextMeshProUGUI>().SetText("Geri Ver");
           
            book.ReturnBook();
            TextUpdate(book);

           
            
               
        }
        else
        {
            borrowButton.GetComponentInChildren<TextMeshProUGUI>().SetText("Ödünç Al");
            book.BorrowBook();
            TextUpdate(book);

        }
    
    }

   
    


}
