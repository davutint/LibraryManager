using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookData : MonoBehaviour
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
            GameObject temp= Instantiate(BookPrefab, ContantArea.position, Quaternion.identity);


            temp.GetComponent<RectTransform>().SetParent(ContantArea,false);
            for (int y = 0; y < Books.Count; y++)
            {
                temp.GetComponent<ContentScript>().VeriAl(Books[i]);
            }

        }

    }
}
