using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class V_health : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    [SerializeField] private AudioSource deathsound;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            Die();
            deathsound.Play();
        }
    }
    

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.Play("V_Die");
        GetComponent<Welp>().enabled = false;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
