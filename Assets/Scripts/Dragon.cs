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

    // Private Atributes
    


    private void Update()
    {
        
       
      // Limitar la rotación en los ejes X y Z a 0
        Vector3 currentRotation = transform.rotation.eulerAngles;
        currentRotation.x = 0;
        currentRotation.z = 0; 
        transform.rotation = Quaternion.Euler(currentRotation);

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
        if(Input.GetKey(KeyCode.A) && gameObject.tag == "Player")
        {           
            print("TECLA A");
            Rotar(-1);
           
        }
        if(Input.GetKey(KeyCode.D) && gameObject.tag == "Player")
        {           
            print("TECLA A");
            Rotar(1);
           
        }
        
        

        //Jump
        if(grounded.isGrounded == true && Input.GetKeyDown(KeyCode.W) && gameObject.tag == "Player")
        {
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

            StartCoroutine(RotateCauseObstacle());
        }   
        
    }
    IEnumerator RotateCauseObstacle()
    {  
        speed = 0;
        Rotar(1);yield return new WaitForSeconds(0.01f);Rotar(1);yield return new WaitForSeconds(0.01f);
        Rotar(1);yield return new WaitForSeconds(0.01f);Rotar(1);yield return new WaitForSeconds(0.01f);
        Rotar(1);yield return new WaitForSeconds(0.01f);Rotar(1);yield return new WaitForSeconds(0.01f);
        Rotar(1);yield return new WaitForSeconds(0.01f);Rotar(1);yield return new WaitForSeconds(0.01f);
        Rotar(1);yield return new WaitForSeconds(0.01f);Rotar(1);yield return new WaitForSeconds(0.01f);
        Rotar(1);yield return new WaitForSeconds(0.01f);Rotar(1);yield return new WaitForSeconds(0.01f);
        Rotar(1);yield return new WaitForSeconds(0.01f);Rotar(1);yield return new WaitForSeconds(0.01f);
        Rotar(1);yield return new WaitForSeconds(0.01f);Rotar(1);yield return new WaitForSeconds(0.01f);
        Rotar(1);yield return new WaitForSeconds(0.01f);Rotar(1);yield return new WaitForSeconds(0.01f);
        Rotar(1);yield return new WaitForSeconds(0.01f);Rotar(1);yield return new WaitForSeconds(0.01f);
        Rotar(1);yield return new WaitForSeconds(0.01f);Rotar(1);yield return new WaitForSeconds(0.01f);
        Rotar(1);yield return new WaitForSeconds(0.01f);Rotar(1);yield return new WaitForSeconds(0.01f);
        
        yield return new WaitForSeconds(1);
         //!!!bloquear la camara 
        speed = 0.02f;
        
        
    }
    
   #endregion

}