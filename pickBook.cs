using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class pickBook : MonoBehaviour
{
    private int books = 0;
    [SerializeField] private TMP_Text bookText;
    [SerializeField] private AudioSource collectbook;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Book"))
        {
            Destroy(collision.gameObject);
            books++;
            Debug.Log("books" + books);
            //bookText.text = "Books: " + books;
            bookText.text = "" + books;
            collectbook.Play();
        }
    }
}
