using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

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
    
    private float rotationAngle = 360; 
    
    

    private void Update()
    {
        
       
        //Moverse 
        if (Input.GetKey(KeyCode.D) && gameObject.tag == "Player")
        {           
            //transform.position += Vector3.right *speed;
            transform.position += transform.TransformDirection(- Vector3.right) *speed ;
            
        }
        
        if (Input.GetKey(KeyCode.L) && gameObject.tag == "Player2")
        {
            transform.position -= Vector3.right * speed;
        }

        //Rotate
        if(Input.GetKeyDown(KeyCode.A) && gameObject.tag == "Player")
        {
            
            //!!! Y tampoco me funciona el rotation
            print("TECLA A");
            
            
           
        }
        

        //Saltar
        if(grounded.isGrounded == true && Input.GetKeyDown(KeyCode.W) && gameObject.tag == "Player")
        {
            transform.position += Vector3.up;
            
        }
        if(grounded.isGrounded == true && Input.GetKeyDown(KeyCode.I) && gameObject.tag == "Player2")
        {
            transform.position += Vector3.up;
            
        }
    }

    private void OnTriggerEnter(Collider other) {
        /*if (obstacle.gameObject.tag == "Obstacle" )
        {
            if (Input.GetKey(KeyCode.D) && gameObject.tag == "Player" && rotationAngle<=360)
            {           Debug.Log("hola");
                transform.RotateAround(transform.position, Vector3.up, rotationAngle *Time.deltaTime * speed);
                rotationAngle++; 
                Debug.Log("rotate");
            }
            
            
        }*/

        
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
        yield return new WaitForSeconds(1);
        GetComponent<Animator>().SetBool("Rotate1", false);
        speed = 0.02f; 
    }
   
}
