using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContentScript : MonoBehaviour
{
    public TextMeshProUGUI KitapAdı;
    public TextMeshProUGUI KitapYazarı;
    public TextMeshProUGUI KitapSayısı;
    public TextMeshProUGUI OduncSayısı;

    

   

    public void VeriAl(Book bookdata)
    {
        KitapAdı.SetText(bookdata.Title);
        KitapYazarı.SetText(bookdata.Author);
        KitapSayısı.SetText(bookdata.TotalCopies.ToString());
        OduncSayısı.SetText(bookdata.BorrowedCopies.ToString());
      
    }


}
