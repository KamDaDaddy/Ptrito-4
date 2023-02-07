using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemi : MonoBehaviour
{
    //publics
    public float speed;

    //privates
    private Rigidbody enemiRb;
    private GameObject larri;
    
    // Start is called before the first frame update
    void Start()
    {
        enemiRb = GetComponent<Rigidbody>();
        larri = GameObject.Find("Larri");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (larri.transform.position - transform.position).normalized;
        
        enemiRb.AddForce(lookDirection * speed);
    }
}
