using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour,IRespawn
{
    private float PlayerSpeed = 5.0f;
    private float JumpHeight = 2.0f;
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
        // Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // transform.position += new Vector3(horizontal, 0, vertical) * PlayerSpeed * Time.deltaTime;
        float xMove = Input.GetAxisRaw("Vertical");
        xMove = -xMove;
        float zMove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(xMove, 0, zMove) * PlayerSpeed;
    }
}
