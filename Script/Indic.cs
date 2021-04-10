using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indic : MonoBehaviour
{
    public Text tuto;


    void Awake()
    {
        tuto = GameObject.FindGameObjectWithTag("Tuto").GetComponent<Text>();
    }


        private void OnTriggerEnter2D(Collider2D collision){
    	if(collision.CompareTag("Player")){
    		
    		
    		tuto.enabled = true;
    	}
    }

    private void OnTriggerExit2D(Collider2D collision){
    	if(collision.CompareTag("Player")){
    		
    	
    		tuto.enabled = false;
    		
    	}
    }
}
