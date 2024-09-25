using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    public bool isGrounded;

   private void Start() 
   {
      isGrounded = true;
   }
   private void OnTriggerEnter(Collider other) 
   {
      print("IsGrounded");
      isGrounded = true;
   }

   private void OnTriggerExit(Collider other) 
   {
      isGrounded = false;
   }
}
