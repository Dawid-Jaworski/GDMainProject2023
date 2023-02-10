using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour,IRespawn
{
    public float PlayerSpeed = 5.0f;
    public float JumpHeight = 2.0f;
    private float gravity = -9.81f;
    Rigidbody rb;
    Transform spawnPoint;
    public void respawn()
    {
        transform.position = spawnPoint.position;
    }


    // Start is called before the first frame update
    void Start()

    {
        CharacterSpawnPointScript character = FindObjectOfType<CharacterSpawnPointScript>();
        spawnPoint = character.transform;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        


        if (Input.GetKey(KeyCode.W))
        {
            transform.position -= PlayerSpeed * transform.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= PlayerSpeed * transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += PlayerSpeed * transform.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += PlayerSpeed * transform.forward * Time.deltaTime;
        }
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * JumpHeight, ForceMode.Impulse);

        }
    }
}
