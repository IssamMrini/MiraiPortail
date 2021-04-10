using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{

	private bool isInRange;
	private Perso playerMovement;

	public BoxCollider2D sol;


    // Start is called before the first frame update
    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Perso>();
    	
    }

    // Update is called once per frame
    void Update()
    {
    	if(isInRange && playerMovement.isClimbing &&  (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))){
    		playerMovement.isClimbing = false;
    		sol.isTrigger = false;
    		return;
    	}

        if(isInRange && (Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.DownArrow))){
        	playerMovement.isClimbing =true;
        	sol.isTrigger = true ;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
    	if(collision.CompareTag("Player")){
    		
    		isInRange = true;
    	}
    }

    private void OnTriggerExit2D(Collider2D collision){
    	if(collision.CompareTag("Player")){
    		
    		isInRange = false;
    		playerMovement.isClimbing =false;
    		sol.isTrigger = false ;
    	}
    }
}
