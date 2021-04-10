using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tourelle : MonoBehaviour
{
     
    [SerializeField]
    GameObject bullet;
    public Rigidbody2D rb;
    public float fireRate;
    float nextFire;
    float distAggro=25f;


    void Start()
    {
        //fireRate = 2f;
        nextFire = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTimeToFire();
    }

    void CheckIfTimeToFire(){
        if (Time.time > nextFire) { 
            if(aPortee()){
                Instantiate (bullet, transform.position, Quaternion.identity);
            }
            nextFire = Time.time + fireRate;
        }
    }
    bool aPortee(){
        GameObject charactere=  GameObject.Find("Personnage");
        float distance = Vector3.Distance (rb.transform.position, charactere.transform.position);
        if(distance>distAggro){
            return false;
        }else{
            return true;
        }
    }

}
