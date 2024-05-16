using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dragon : MonoBehaviour
{
    //Public Properties
    
    public string nameDragon;
    [SerializeField] float speed = 0.02f; 
    public float speedRotation; 
   


    public float resistObstacles; 
    public int specialPower;

    public float jump; 

    //Public Scripts 
    public Grounded grounded;
    public Meta meta;

    // Private Atributes
    


    private void Update()
    {
        //!!!bloquear la camara 
        
      // Limitar la rotación en los ejes X y Z a 0
        Vector3 currentRotation = transform.rotation.eulerAngles;
        currentRotation.x = 0;
        currentRotation.z = 0; 
        transform.rotation = Quaternion.Euler(currentRotation);

        if(meta.GameOn == true)
        {
            //Moverse 
            if (Input.GetKey(KeyCode.W) && gameObject.tag == "Player")
            {           
                transform.position -= transform.right *speed ;
            
            }
            if (Input.GetKey(KeyCode.S) && gameObject.tag == "Player")
            {           
                transform.position += transform.right *speed ;
            
            }
        
            if (Input.GetKey(KeyCode.I) && gameObject.tag == "Player2")
            {
                transform.position -= transform.right * speed;
            }
            if (Input.GetKey(KeyCode.K) && gameObject.tag == "Player2")
            {
                transform.position += transform.right * speed;
            }

        }

        //Rotate
        if(Input.GetKey(KeyCode.A) && gameObject.tag == "Player")
        {           
            Rotar(-1);
           
        }
        if(Input.GetKey(KeyCode.D) && gameObject.tag == "Player")
        {           
            Rotar(1);
           
        }
        
        

        //Jump
        if(grounded.isGrounded == true && Input.GetKeyDown(KeyCode.Space) && gameObject.tag == "Player")
        {
            gameObject.GetComponent<Rigidbody>().mass = 0.1f;  
            transform.position += Vector3.up * jump;
                  
        }
        if(grounded.isGrounded == true && Input.GetKeyDown(KeyCode.I) && gameObject.tag == "Player2")
        {
            transform.position += Vector3.up * jump;
            
        }
        
    }

#region Rotar al chocar con obstaculo
    void Rotar(int direccion)
    {
        //Calcular angulo de rotacion
        float rotation = speedRotation * direccion ;

        //Rotar personaje
        //transform.Rotate(Vector3.up, rotation);
        transform.Rotate(0, rotation, 0);

    }
    private void OnTriggerEnter(Collider other) {
       
      
        if(other.gameObject.tag == "Obstacle")
        {
            print("StartCoroutine");
            StartCoroutine(RotateCauseObstacle());
        }   
        
    }
    IEnumerator RotateCauseObstacle()
    {  
        print("RotateCauseObstacle");
        speed = 0;
        speedRotation = 10; 
        Quaternion startRotation = transform.rotation;
        Vector3 startPosition = transform.position;

        
        for(int i = 0; i < 10; i++)
        {
            Rotar(1);yield return new WaitForSeconds(0.03f);
            i++;
            
        }
        //Se coloca en la misma rotacion y salta el obstaculo en x
        transform.rotation = startRotation; 
        transform.position = new Vector3 (startPosition.x - 1f, startPosition.y, startPosition.z);
        //Restablece los valores
        yield return new WaitForSeconds(0.5f);    
        speed = 0.02f;
        speedRotation = 0.2f;
        
        
    }
    
   #endregion

}