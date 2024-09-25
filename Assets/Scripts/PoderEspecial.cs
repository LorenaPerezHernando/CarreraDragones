using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PoderEspecial : MonoBehaviour
{
    //Public Propertoes
    public string namePower;
    public int numPoder;
    public Image tintaRival;
    
    [SerializeField] bool quitarObstaculos;

    //!!ME FALTA EL COMO ACTIVAR UN CIRCULO PARA SABER QUE PODER TIENES
    //PERO NO SE COMO HACER QUE SEPA SI ES DE AMIGO O RIVAL Y DE QUE COLOR TIENE QUE SER 


    //Private Attributes
    string _namePower;
    float _specialPower;

    public GameObject rival;
    public Transform camRival;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            rival = GameObject.FindWithTag("Player2");
            camRival = rival.transform.Find("Camera");
            //tintaRival en posicion de la camara rival

            //!!LO DEL CIRCULO; PROBAR AQUI A PONER SI INT 1 Activar circuloJ1_1 Si INT 2 Activar CirculoJ1_2
           
            StartCoroutine(StartPower());
        }
        if (other.gameObject.tag == ("Player2"))
        {
            rival = GameObject.FindWithTag("Player");
            camRival = rival.transform.Find("Camera");
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
            //Activar circulo con el color del poder 
        }
        if (numPoder == 2)
        {
            print("Tinta");
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
    }
}
