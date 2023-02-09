using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemi : MonoBehaviour
{
    //publics
    public float speed;
    public GameObject EnemiPrefab;

    //privates
    private Rigidbody enemiRb;
    private GameObject larri;
    
    // Start is called before the first frame update
    void Start()
    {
        enemiRb = GetComponent<Rigidbody>();
        larri = GameObject.Find("Larri");

        Instantiate(EnemiPrefab, new Vector3(0, 0, 6), EnemiPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (larri.transform.position - transform.position).normalized;
        
        enemiRb.AddForce(lookDirection * speed);
    }
}
