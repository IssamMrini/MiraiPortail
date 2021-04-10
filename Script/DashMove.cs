using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{
	private Rigidbody2D rb;
	public float dashSpeed=50f;
	private float dashTime;
	public float startDashTime=2.0f;
	private int direction=0;
	public GameObject charactere;
    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        dashTime=startDashTime;
         charactere = GameObject.Find("Personnage");
    }

    // Update is called once per frame
    void Update(){
       
    }
    void FixedUpdate(){
    	if(direction == 0){ // pas de direction 
       		if(Input.GetKeyDown(KeyCode.W)){
       			Debug.Log("W"); // dash gauche
       			direction=1;
       		}else if(Input.GetKeyDown(KeyCode.X)){
       			Debug.Log("X");  // dash droit
       			direction = 2 ;
       		}
       }else{ 
	       	if(dashTime<=0){
	       		changeStateDash(false);
	       		direction = 0;
	       		dashTime= startDashTime;
	       		rb.velocity = Vector2.zero;
	       	}else{ // je suis en train de dash 
	       		dashTime-=Time.deltaTime;
	       		changeStateDash(true);
	       		if(direction == 1){
	       			rb.velocity=Vector2.left*dashSpeed;
	       		}else if(direction == 2){
	       			rb.velocity = Vector2.right*dashSpeed;
	       		}
	       	}
	    }

    }

    public void changeStateDash(bool var){
    	CharactereState etat = charactere.gameObject.GetComponent<CharactereState>();
	    etat.isDashing=var;
    }
}
