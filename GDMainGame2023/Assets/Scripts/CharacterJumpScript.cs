using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJumpScript : MonoBehaviour
{
    public float jumpforce = 10f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);

        }

    }

}
