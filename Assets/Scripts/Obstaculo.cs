using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    //Public Propierties
    public GameObject obstaculo; //!!Puede que tenga que hacer un array 

    void Start()
    {
        
    }

   private void OnCollisionEnter(Collision other) 
   {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Player2")
        {
           //Rotar alrededor de este objeto 
        }
        
   }
    
}
