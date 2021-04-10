using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Follow : MonoBehaviour
{
    public Text touches;

    void Awake()
    {
        touches = GameObject.FindGameObjectWithTag("Follow").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision){

    	if(collision.CompareTag("Player")){
    		touches.enabled = false;
    	}

    }


}
