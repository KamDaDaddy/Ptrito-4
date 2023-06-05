using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public
    public float speed = 15.0f;
    public bool hasPowerup;
    public GameObject powerusIndicator;
    public GameObject isLitPrefab;
    

    //privates
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private float powerupStrength = 15.0f;

    Vector3 offset = new Vector3(0.15f, 0, 1.5f);
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
        powerusIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(isLitPrefab, transform.position + offset, isLitPrefab.transform.rotation);
        }

    }
    //Powerup script
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;

            Destroy(other.gameObject);
            powerusIndicator.gameObject.SetActive(true);
            
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
            //enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            
            
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;

        powerusIndicator.gameObject.SetActive(false);
    }




}
