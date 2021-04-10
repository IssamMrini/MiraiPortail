﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
   private Transform playerSpawn;

		
   		private void Awake(){
   			playerSpawn = GameObject.FindGameObjectWithTag("Respawn").transform; 
   		}

      private void OnTriggerEnter2D(Collider2D collision){

    	if(collision.CompareTag("Player")){
            Debug.Log("Dead!");
            collision.transform.position = playerSpawn.position;
        }
    }
}
