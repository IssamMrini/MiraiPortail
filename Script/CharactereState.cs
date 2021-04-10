using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactereState : MonoBehaviour
{
    public bool isTouchable;
    public bool isDashing;
    
    void Start(){
        isTouchable=true;
        isDashing=false;
    }

    // Update is called once per frame
    void Update(){
        if(isDashing){
        	isTouchable=false;
        }else{
        	isTouchable=true;;
        }
    }
}
