using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Private Atributes
    


    private void Update()
    {
        
       
        //Moverse 
        if (Input.GetKey(KeyCode.S) && gameObject.tag == "Player")
        {           
            //transform.position += Vector3.right *speed;
            transform.position -= transform.right *speed ;
            
        }
        
        if (Input.GetKey(KeyCode.K) && gameObject.tag == "Player2")
        {
            transform.position -= transform.right * speed;
        }

        
        //Rotate
        if(Input.GetKeyDown(KeyCode.A) && gameObject.tag == "Player")
        {           
            print("TECLA A");
            Rotar(-1);
           
        }
        if(Input.GetKeyDown(KeyCode.D) && gameObject.tag == "Player")
        {           
            print("TECLA A");
            Rotar(1);
           
        }
        
        

        //Saltar
        if(grounded.isGrounded == true && Input.GetKeyDown(KeyCode.W) && gameObject.tag == "Player")
        {
           transform.position += Vector3.up ;
            
        }
        if(grounded.isGrounded == true && Input.GetKeyDown(KeyCode.I) && gameObject.tag == "Player2")
        {
            transform.position += Vector3.up ;
            
        }
        
    }

    void Rotar(int direccion)
    {
        //Calcular angulo de rotacion
        float rotation = speedRotation * direccion ;

        //Rotar personaje
        transform.Rotate(Vector3.up, rotation);
        //transform.Rotate(0, rotation, 0);

    }
#region Rotar al chocar con obstaculo
    private void OnTriggerEnter(Collider other) {
       
        if(other.gameObject.tag == "Obstacle")
        {

            StartCoroutine(RotateCauseObstacle());
        }   
        
    }
    IEnumerator RotateCauseObstacle()
    {  
        print("AnimatorRotate");
        GetComponent<Animator>().SetBool("Rotate1", true);
        speed = 0; 
        yield return new WaitForSeconds(1); //!!!bloquear la camara 
        GetComponent<Animator>().SetBool("Rotate1", false);
        speed = 0.02f; 
    }
    
   #endregion

}