using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public
    public float speed = 15.0f;

    //privates
    private Rigidbody playerRb;
    private GameObject focalPoint;
    //private horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        
        //horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

    }
}
