using System;
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
    private float stoppedThreshold = 0.01f;
    private float MouseSensitivity = 0.5f;
    private readonly float cameraDistance = 7f;
    float forward, right;
    Animator myAnimator;
    private float heightCam = 2;

    public void respawn()
    {
        transform.position = spawnPoint.position;
    }


    // Start is called before the first frame update
    void Start()

    {
        myAnimator = GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Camera.main.transform.rotation = transform.rotation;
        Camera.main.transform.position = transform.position - cameraDistance * transform.forward + heightCam *Vector3.up;
        CharacterSpawnPointScript character = FindObjectOfType<CharacterSpawnPointScript>();
        spawnPoint = character.transform;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        forward = 0;
        right = 0;
        Vector3 lastPosition = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += PlayerSpeed * transform.forward * Time.deltaTime;
            forward = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= PlayerSpeed * transform.forward * Time.deltaTime;
            forward = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += PlayerSpeed * transform.right * Time.deltaTime;
            right = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= PlayerSpeed * transform.right * Time.deltaTime;
            right = -1;
        }
        

        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.AddForce(Vector3.up * JumpHeight, ForceMode.Impulse);

        }

        transform.Rotate(Vector3.up, MouseSensitivity*Input.GetAxis("Horizontal"));
     Camera.main.transform.RotateAround( transform.position, transform.right,- MouseSensitivity * Input.GetAxis("Vertical"));
        if (Vector3.Dot(Camera.main.transform.forward , transform.forward) < Mathf.Cos(45 * Mathf.Deg2Rad))
            Camera.main.transform.RotateAround(transform.position, transform.right, MouseSensitivity * Input.GetAxis("Vertical"));
        //  Camera.main.transform.LookAt(transform.position, Vector3.up);


        myAnimator.SetFloat("forward",forward);
        print(forward);
        myAnimator.SetFloat("right", right);

    }

    private bool isGrounded()
    {
        return MathF.Abs(rb.velocity.y) < stoppedThreshold;
    }
}
