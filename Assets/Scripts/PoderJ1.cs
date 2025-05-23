using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PoderJ1 : MonoBehaviour
{
    //Public Propertoes
    public int numPoder;
    public Dragon dragon;

    public Image circuloPoderActivado;
    public GameObject tintaJ2;
    public bool quitarObstaculos;

    public GameObject rival;



    void Start()
    {
        tintaJ2.SetActive(false);
        circuloPoderActivado.enabled = false;
        quitarObstaculos = false;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (numPoder == 1)
                StartCoroutine(Ralentizar());

            if(numPoder == 2)
                StartCoroutine(TintaRival());
            if(numPoder == 3)
                StartCoroutine(QuitarObstaculos());

        }
    }

    public IEnumerator Ralentizar()
    {
        float speedInicial = rival.GetComponent<Dragon>().speed;
        print("Relentizar al compa�ero");
        circuloPoderActivado.color = Color.yellow;
        rival.GetComponent<Dragon>().speed = 2;  
        
        yield return new WaitForSeconds(4);

        circuloPoderActivado.enabled = false; 
        rival.GetComponent <Dragon>().speed = speedInicial;
        numPoder = 0;
    }

    public IEnumerator TintaRival()
    {
        print("Tinta");
        circuloPoderActivado.color = Color.yellow;
        tintaJ2.SetActive(true);

        yield return new WaitForSeconds(4);

        circuloPoderActivado.enabled = false;
        tintaJ2.SetActive(false);
        numPoder = 0;
    }

    public IEnumerator QuitarObstaculos()
    {
        circuloPoderActivado.color = Color.yellow;
        dragon.quitarObstaculos = true;
        
        print("Quitar Obstaculos");

        yield return new WaitForSeconds(7);
        circuloPoderActivado.enabled = false;
        quitarObstaculos = false;
        dragon.quitarObstaculos = false;
        numPoder = 0; 
    }



}
