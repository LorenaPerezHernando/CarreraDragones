using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Meta : MonoBehaviour
{
    //Public Properties
    public bool GameOn = false; 
    public GameObject panelWinnerP1;
    public GameObject panelWinnerP2;

    public GameObject panelInstrucciones;
    public GameObject checkP1;
    public GameObject checkP2;

    public TextMeshProUGUI panelCountdown;
    public GameObject panelReady;


    //Private Properties
    bool P1Ready = false;
    bool P2Ready = false;

    private void Start() 
    {
        panelWinnerP1.SetActive(false);
        panelWinnerP2.SetActive(false);
        panelReady.SetActive(false);
        GameOn = false;

        

        panelInstrucciones.SetActive(true);
    }

    public void Player1Ready()
    {
        P1Ready = true;
        checkP1.SetActive(false );
        StartCoroutine(ActivarJuego());
    }
    public void Player2Ready()
    {
        P2Ready = true;
        checkP2.SetActive(false );
        StartCoroutine(ActivarJuego());
    }

    IEnumerator ActivarJuego()
    {
        if (P1Ready && P2Ready)
        {
            panelInstrucciones.SetActive(false );
            panelReady.SetActive(true);

            yield return new WaitForSeconds(1);
            panelCountdown.GetComponent<TextMeshProUGUI>().text = "  2";
            yield return new WaitForSeconds(1);
            panelCountdown.GetComponent<TextMeshProUGUI>().text = "  1";
            yield return new WaitForSeconds(1);
            panelCountdown.GetComponent<TextMeshProUGUI>().text = "GO!!";
            yield return new WaitForSeconds(0.5f);

            panelReady.SetActive(false);
            GameOn = true;
            
        }


    }
    
    private void OnCollisionEnter(Collision other)
    {
        print("Winner");
        if(other.gameObject.tag == "Player")
        {
            panelWinnerP1.SetActive(true);
            GameOn = false;

        }   
        if(other.gameObject.tag == "Player2")
        {
            panelWinnerP2.SetActive(true);
            GameOn = false ;
        }
    }
}
