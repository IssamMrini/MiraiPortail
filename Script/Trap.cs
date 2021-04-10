using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

	public Animator animator;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision){
    	if(collision.CompareTag("Player")){
    			

    			animator.SetBool("Touch", true);
    			Debug.Log("HIT !");
    			Perso.instance.Die();

   	 	}
	}
}
