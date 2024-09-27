using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PoderEspecial : MonoBehaviour
{
    //PONERLO EN LOS PODERES 

    public GameObject player;
    public GameObject player2; 

    public string nombrePoder;
    public int numPoderEspecial;
    public Image poderActivadoJ1;
    public Image poderActivadoJ2;

    public PoderJ1 poderJ1;
    public PoderJ2 poderJ2;


    private void Start()
    {
        poderJ1 = GameObject.FindGameObjectWithTag("Player").GetComponent<PoderJ1>();
        poderJ2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PoderJ2>();
        poderActivadoJ1.enabled = false;
        poderActivadoJ2.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger con " + other.gameObject.tag);
        if (other.gameObject.tag == "Player2")
        {
            print("Player2");
            if (numPoderEspecial == 1)
            {
                print("Player2 int1");
                poderJ2.numPoder = 1;
                poderActivadoJ2.enabled = true;
                poderActivadoJ2.color = Color.magenta;

            }

            if (numPoderEspecial == 2)
            {
                poderJ2.numPoder = 2;
                poderActivadoJ2.enabled = true;
                poderActivadoJ2.color = Color.blue;
            }

            if (numPoderEspecial == 3)
            {
                poderJ2.numPoder = 3;
                poderJ2.quitarObstaculos = true;
                poderActivadoJ2.enabled = true;
                poderActivadoJ2.color = Color.green;
            }
        }

        else if (other.gameObject.tag == "Player")
        {
            print("Player1 Trigger Enter");
            if (numPoderEspecial == 1 )
            {
                poderJ1.numPoder = 1;
                poderActivadoJ1.enabled = true;
                poderActivadoJ1.color = Color.magenta;

            }

            if (numPoderEspecial == 2)
            {
                poderJ1.numPoder = 2;
                poderActivadoJ1.enabled = true;
                poderActivadoJ1.color = Color.blue;
            }

            if (numPoderEspecial == 3)
            {
                poderJ1.numPoder = 3;
                poderJ1.quitarObstaculos = true;
                poderActivadoJ1.enabled = true;
                poderActivadoJ1.color = Color.green;
            }
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colision con " + gameObject.name);
        if (collision.gameObject.tag == "Player2")
        {
            print("Player2");
            if (numPoderEspecial == 1)
            {
                print("Player2 int1");
                poderJ2.numPoder = 1;
                poderActivadoJ2.enabled = true;
                poderActivadoJ2.color = Color.magenta;

            }

            if (numPoderEspecial == 2)
            {
                poderJ2.numPoder = 2;
                poderActivadoJ2.enabled = true;
                poderActivadoJ2.color = Color.blue;
            }

            if (numPoderEspecial == 3)
            {
                poderJ2.numPoder = 3;
                poderActivadoJ2.enabled = true;
                poderActivadoJ2.color = Color.green;
            }
        }

        else if (collision.gameObject.tag == "Player")
        {
            print("Player1 Trigger Enter");
            if (numPoderEspecial == 1 && collision.gameObject.tag == "Player")
            {
                poderJ1.numPoder = 1;
                poderActivadoJ1.enabled = true;
                poderActivadoJ1.color = Color.magenta;

            }

            if (numPoderEspecial == 2 && collision.gameObject.tag == "Player")
            {
                poderJ1.numPoder = 2;
                poderActivadoJ1.enabled = true;
                poderActivadoJ1.color = Color.blue;
            }

            if (numPoderEspecial == 3 && collision.gameObject.tag == "Player")
            {
                poderJ1.numPoder = 3;
                poderActivadoJ1.enabled = true;
                poderActivadoJ1.color = Color.green;
            }
        }

    }


}
