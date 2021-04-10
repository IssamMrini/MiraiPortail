using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

	float moveSpeed = 10f;

	Rigidbody2D rb;

	Perso target;
	Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
    	rb = GetComponent<Rigidbody2D>();
    	target = GameObject.FindObjectOfType<Perso>();
    	moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
    	rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    	Destroy (gameObject, 5f);
        
    }


    void OnTriggerEnter2D (Collider2D col){
    	
    	if(col.gameObject.name.Equals ("Personnage")) {
    		Debug.Log("HIT !");
    		Perso.instance.Die();
         //   GameOver.instance.OnPlayerDeath();
    	}
    }
}
