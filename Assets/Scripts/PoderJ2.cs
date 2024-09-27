using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoderJ2 : MonoBehaviour
{
    //Public Propertoes
    public int numPoder;

    public Image circuloPoderActivado;
    public GameObject tintaJ1;
    public bool quitarObstaculos;
    public Dragon dragon;

    public GameObject rival;



    void Start()
    {
        tintaJ1.SetActive(false);
        circuloPoderActivado.enabled = false;
        quitarObstaculos = false;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            if (numPoder == 1)
                StartCoroutine(Ralentizar());

            if (numPoder == 2)
                StartCoroutine(TintaRival());
            if (numPoder == 3)
                StartCoroutine(QuitarObstaculos());

        }
    }

    public IEnumerator Ralentizar()
    {
        float speedInicial = rival.GetComponent<Dragon>().speed;
        print("Relentizar al compañero");
        rival.GetComponent<Dragon>().speed = 2;

        yield return new WaitForSeconds(4);

        circuloPoderActivado.enabled = false;
        rival.GetComponent<Dragon>().speed = speedInicial;
        numPoder = 0;
    }

    public IEnumerator TintaRival()
    {
        print("Tinta");
        circuloPoderActivado.color = Color.yellow;
        tintaJ1.SetActive(true);

        yield return new WaitForSeconds(4);

        circuloPoderActivado.enabled = false;
        tintaJ1.SetActive(false);
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

    private void OnTriggerEnter(Collider other)
    {
        if (quitarObstaculos == true && other.gameObject.tag == "Obstaculo")
            Destroy(other.gameObject);
    }


}
