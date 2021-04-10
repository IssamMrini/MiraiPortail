using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actif : MonoBehaviour
{
    public Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision){
    	if(collision.CompareTag("Player")){
    			
    			Debug.Log("HIT !");
    			rb.simulated = true;
   	 	}
	}
}
