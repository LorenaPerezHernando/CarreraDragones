using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PoderEspecial : MonoBehaviour
{
    //PONERLO EN LOS PODERES 

    //Public Propertoes
    public string namePower;
    public Image tintaRival;
    Image circuloPoder1;
    Image circuloPoder2;
    public Color color;
    
    [SerializeField] bool quitarObstaculos;
    public GameObject rival;
    public Transform camRival;

    //!!ME FALTA EL COMO ACTIVAR UN CIRCULO PARA SABER QUE PODER TIENES
    //PERO NO SE COMO HACER QUE SEPA SI ES DE AMIGO O RIVAL Y DE QUE COLOR TIENE QUE SER 


    //Private Attributes
    int numPoder;
    string _namePower;
    float _specialPower;


    private void Start()
    {
        tintaRival.enabled = false;
        circuloPoder1.enabled = false;
        circuloPoder2.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == ("Player"))
        {
            rival = GameObject.FindWithTag("Player2");
            camRival = rival.transform.Find("Camera");
            //tintaRival en posicion de la camara rival
            tintaRival.GetComponent<RectTransform>();
            tintaRival.transform.position = camRival.transform.position;
            

            //!!LO DEL CIRCULO; PROBAR AQUI A PONER SI INT 1 Activar circuloJ1_1 Si INT 2 Activar CirculoJ1_2
           
            StartCoroutine(StartPower());
        }
        if (other.gameObject.tag == ("Player2"))
        {
            rival = GameObject.FindWithTag("Player");
            camRival = rival.transform.Find("Camera");
            tintaRival.GetComponent<RectTransform>();
            tintaRival.transform.position = camRival.transform.position;

            circuloPoder2.enabled = true;

            //tintaRival en posicion de la camara rival

            StartCoroutine(StartPower());
        }
    }

    IEnumerator StartPower()
    {
        if(numPoder == 1)
        {
            print("Relentizar al compañero");
            rival.GetComponent<Dragon>().speed = 2;
            circuloPoder1.enabled=true;
            //Activar circulo con el color del poder 
        }
        if (numPoder == 2)
        {
            print("Tinta");
            tintaRival.enabled = true;
            //Posicion cam -1x y activar tinta rival
        }
        if(numPoder == 3)
        {
            print("Desactivar obstaculos");
            //Bool QuitarObstaculos y que el script dragon acceda a el en el trigger enter 
            //Pero hacer que no entre en el primer if, osea ponerlo como el primer if 
        }
        yield return new WaitForSeconds(2);
        //Restablecer los valores del bool y speed
        rival.GetComponent<Dragon>().speed = 4;
        tintaRival.enabled = false; 
    }
}
