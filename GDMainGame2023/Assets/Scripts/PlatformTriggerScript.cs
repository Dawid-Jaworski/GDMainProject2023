using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTriggerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject linkedPlatform;
    MovingPlatfromScript platform;
    void Start()
    {
        platform = linkedPlatform.GetComponent<MovingPlatfromScript>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        platform.startPlatformMovement();
    }
}
