using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Welp welp;
    // Start is called before the first frame update
   public void Jumpnow()
   {
       welp.Jump();
   }

}
