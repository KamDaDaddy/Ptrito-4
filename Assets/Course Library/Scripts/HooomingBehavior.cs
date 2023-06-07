using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HooomingBehavior : MonoBehaviour
{   
        //public variables


        //private variables
    private Transform targetto;
    private bool homing = false;

    private float speed = 20.0f;
    private float iSeeBeeM = 25.0f;
    private float timeTilSuicide = 5.0f;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(Transform newTargetto)
    {
        targetto = homingTargetto;
        homing = true;

        Destroy(gameObject, timeTilSuicide);
    }


}
