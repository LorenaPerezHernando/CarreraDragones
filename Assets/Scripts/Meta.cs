using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meta : MonoBehaviour
{
    //Public Properties
    public bool GameOn = true; 
    public GameObject panelP1;
    public GameObject panelP2;


    //Private Properties

    private void Start() 
    {
        panelP1.SetActive(false);
        panelP2.SetActive(false);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            panelP1.SetActive(true);
            GameOn = false;

        }   
        if(other.gameObject.tag == "Player2")
        {
            panelP2.SetActive(true);
            GameOn = false ;
        }
    }
}
