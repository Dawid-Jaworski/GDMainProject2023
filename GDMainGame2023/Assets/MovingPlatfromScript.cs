using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatfromScript : MonoBehaviour
{

    enum MovingPlatformState { InWall, Extended, GoingOut, ReturningToWall}
    MovingPlatformState currently = MovingPlatformState.InWall;
    private float goingOutSpeed = 2, returningSpeed = 1, extendtedTime = 4;
    Vector3 defaultPosition,extendedPosition;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        defaultPosition = transform.position;
        extendedPosition = defaultPosition + transform.localScale.z * transform.forward;
    }

    // Update is called once per frame
    void Update()
    {

        switch(currently)
        {
            case MovingPlatformState.InWall:

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    startPlatformMovement();
                }
              
                break;

            case MovingPlatformState.Extended:
                timer += Time.deltaTime;
                if (timer >= extendtedTime)
                {
                    currently = MovingPlatformState.ReturningToWall;
                    timer = 0;
                }

                break;

            case MovingPlatformState.GoingOut:

                transform.position = Vector3.Lerp(defaultPosition, extendedPosition, timer);
                timer += goingOutSpeed * Time.deltaTime;
                if (timer >= 1)
                {
                    currently = MovingPlatformState.Extended;
                    transform.position = extendedPosition;
                }

                break;

            case MovingPlatformState.ReturningToWall:

                
                transform.position = Vector3.Lerp(extendedPosition, defaultPosition, timer);
                timer += returningSpeed* Time.deltaTime;  
                if (timer >=1 )
                {
                    currently = MovingPlatformState.InWall;
                    transform.position = defaultPosition;
                }




                break;

        }
        
    }

    internal void startPlatformMovement()
    {
        currently = MovingPlatformState.GoingOut;
        timer = 0;
    }
}
