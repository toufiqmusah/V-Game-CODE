using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike_hurt : MonoBehaviour
{

    [SerializeField] private float AttackDamage;
    [SerializeField] private float AttackingSpeed = 0.8f;
    private float CanAttack;

    private Welp player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "V")
        {

            if (AttackingSpeed <= CanAttack)
            {
                //other.gameObject.GetComponent<V_health>().UpdateHealth(-AttackDamage);
                CanAttack = 0f;
            }
            else
            {
                CanAttack += Time.deltaTime;
            }
        }

    }


}
