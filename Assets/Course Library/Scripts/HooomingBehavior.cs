using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HooomingBehavior : MonoBehaviour
{   
        //public variables
    public float speed;
    public Rigidbody targettoRb;

        //private variables
    private Transform targetto;
    private bool homing = false;

    private float iSeeBeeM = 25.0f;
    private float timeTilSuicide = 5.0f;

    void Awake()
    {
        Debug.Log("Oh hi there!");
    }
    
    // Update is called once per frame
    void Update()
    {
        if(homing && targetto != null)
        {
            //If both homing and target are true, approach in a straight line
            Vector3 moveDirection = (targetto.transform.position - transform.position).normalized;
            transform.position += moveDirection * speed * Time.deltaTime;

            transform.LookAt(targetto);
        }
    }

    public void Fire(Transform newTargetto)
    {
        //targetto = homingTargetto;
        homing = true;

        Destroy(gameObject, timeTilSuicide);
    }

    void OnCollisionEnter(Collision other)
    {
            //If target is not null, run code below
        if (targetto != null)
        {
                //Checks if the other colliding object has the same tag as the target
            if(other.gameObject.CompareTag(targetto.tag))
            {
                    //If it's the same, get the rigidbody of the other gameobject
                targettoRb = other.gameObject.GetComponent<Rigidbody>();

                    //;)
                Vector3 away = other.contacts[0].normal;
                targettoRb.AddForce(away * iSeeBeeM, ForceMode.Impulse);

                Destroy(gameObject);
            }
        }
    }


}
