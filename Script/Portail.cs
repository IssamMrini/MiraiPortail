using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Portail : MonoBehaviour
{
    public string lvltoload;

    private void OnTriggerEnter2D(Collider2D collision){
    	if(collision.CompareTag("Player")){
    		
    			SceneManager.LoadScene(lvltoload);
   	 	}
	} 
}
