using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Dragon : MonoBehaviour
{
    //Public Properties
    //Pruba para github, borrar despues
    public Transform quitarCam;

    public bool quitarObstaculos;

    public string nameDragon;
    public float resistObstacles; 
    public float speed = 4f;


    // Private Atributes
    float speedRotation = 90;
    float jump = 100; 
    GameObject obstaculoActual;
    Vector3 rotacionInicial;

    //Public Scripts 
    public Grounded grounded;
    public Meta meta;

    private void Update()
    {               
      // Limitar la rotación en los ejes X y Z a 0
        Vector3 currentRotation = transform.rotation.eulerAngles;
        currentRotation.x = 0;
        currentRotation.z = 0; 
        transform.rotation = Quaternion.Euler(currentRotation);

        if(meta.GameOn == true)
        {
         #region Moverse !!!
            if (Input.GetKey(KeyCode.W) && gameObject.tag == "Player")
            {           
                transform.position -= transform.right *speed *Time.deltaTime;
            
            }

            ////Ir hacia atras
            //if (Input.GetKey(KeyCode.S) && gameObject.tag == "Player")
            //{           
            //    transform.position += transform.right *speed ;
            
            //}
        
            if (Input.GetKey(KeyCode.UpArrow) && gameObject.tag == "Player2")
            {
                transform.position -= transform.right * speed * Time.deltaTime;
            }
            //if (Input.GetKey(KeyCode.DownArrow) && gameObject.tag == "Player2")
            //{
            //    transform.position += transform.right * speed;
            //}

        #endregion
         #region Rotate
            if (Input.GetKey(KeyCode.A) && gameObject.tag == "Player")                  
                Rotar(-1);          
        
            if(Input.GetKey(KeyCode.D) && gameObject.tag == "Player")           
                Rotar(1);


            if(Input.GetKey(KeyCode.LeftArrow) && gameObject.tag == "Player2")      
                Rotar2(-1);
        

            if (Input.GetKey(KeyCode.RightArrow) && gameObject.tag == "Player2")
                Rotar2(1);

            #endregion
            #region Jump !!!
            if (grounded.isGrounded == true && Input.GetKeyDown(KeyCode.S) && gameObject.tag == "Player")
            {
            //gameObject.GetComponent<Rigidbody>().mass = 0.1f;  
            transform.position += Vector3.up * jump * Time.deltaTime;
                  
            }
            if(grounded.isGrounded == true && Input.GetKeyDown(KeyCode.DownArrow) && gameObject.tag == "Player2")
            {
            transform.position += Vector3.up * jump * Time.deltaTime;
            
            }
        #endregion 
        }

    }

    #region Rotar al chocar con obstaculo
    void Rotar(int direccion)
    {
        //Calcular angulo de rotacion
        float rotation = speedRotation * direccion * Time.deltaTime;

        //Rotar personaje
        //transform.Rotate(Vector3.up, rotation);
        transform.Rotate(0, rotation, 0);

    }
    void Rotar2(int direccion)
    {
       
        //Calcular angulo de rotacion
        float rotation = speedRotation * direccion * Time.deltaTime;

        //Rotar personaje
        //transform.Rotate(Vector3.up, rotation);
        transform.Rotate(0, rotation, 0);

    }
    private void OnTriggerEnter(Collider other) {
       
      //!!! Tendre que tener un GameObject Player y Player2 para que no roten? 

        if(other.gameObject.tag == "Obstacle" && quitarObstaculos == false)
        {
            Vector3 rotacionInicial = this.transform.rotation.eulerAngles;
            print("StartCoroutine");
            StartCoroutine(RotateCauseObstacle());
            obstaculoActual = other.gameObject;
            print("Fin Obstaculo");
            
            
        }   
        
    }
    IEnumerator RotateCauseObstacle()
    {
        //Desvincular la camara y guardar los datos antes de girar 
        
        quitarCam.SetParent(null);
        Quaternion startRotation = transform.rotation;
        print("rotacion P1: " + startRotation);
        Vector3 startPosition = transform.position;

        print("RotateCauseObstacle");
        speed = 0;
        speedRotation = 600; 

        
        for(int i = 0; i < 10; i++)
        {
            Rotar(1);yield return new WaitForSeconds(0.03f);
            i++;
            
        }
        //Se coloca en la misma rotacion y salta el obstaculo en x
       
        transform.rotation = startRotation; print("rotacion P1: " + startRotation);
        //transform.position = new Vector3 (startPosition.x -1, startPosition.y, startPosition.z);

        //Restablece los valores
        yield return new WaitForSeconds(0.5f);
        quitarCam.SetParent(transform);
        quitarCam.localPosition = new Vector3(4.4f, 5.2f, -0.9f);
        quitarCam.localEulerAngles = new Vector3(30.5f, 283, 359.6f);
        speed = 4;
        speedRotation = 90;
        //transform.eulerAngles = rotacionInicial;
        Destroy(obstaculoActual);
        
    }
    
   #endregion

}