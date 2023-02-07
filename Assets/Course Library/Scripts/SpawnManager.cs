using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject EnemiPrefab;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(EnemiPrefab, new Vector3(0, 0, 6), EnemiPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
