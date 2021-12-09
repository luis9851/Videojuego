using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
   public Animator animator;
   private void OnTriggerEnter2D(Collider2D other){
       /* Debug.Log("Interacción con Bandera"); */
       animator.SetBool("Active",true);
   }
}
