using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ToNextLevel : MonoBehaviour
{

    public int nextSceneLoad;
    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("V"))
        {
            if (SceneManager.GetActiveScene().buildIndex == 6)
            {
                Debug.Log("Win");
            }

            else
            {
                SceneManager.LoadScene(nextSceneLoad);

                if(nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
               {
                    PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                }
            }

           
        }

        
    }
}
