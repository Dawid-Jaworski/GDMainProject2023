using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatfromScript : MonoBehaviour
{
    public bool staysExtended = false;
    enum MovingPlatformState { InWall, Extended, GoingOut, ReturningToWall, GoingUp, GoingDown, isElevator}
    MovingPlatformState currently = MovingPlatformState.InWall;
    public float goingOutSpeed = 2, returningSpeed = 1, extendtedTime = 4;
    Vector3 defaultPosition,extendedPosition;

    public Transform extendedPositionTarget0;
    public Transform extendedPositionTarget1;
    private float timer;

    public Transform linkedPlatform;
    MovingPlatfromScript linkePlatformScript;
    private Vector3 raisedElevatorPosition;
    private bool isElevator;


    // Start is called before the first frame update
    void Start()
    {
        defaultPosition = transform.position;
        if (extendedPositionTarget0)
            extendedPosition = extendedPositionTarget0.position;
        else
        extendedPosition = defaultPosition + transform.localScale.z * transform.forward;

        if (extendedPositionTarget1)
        {
            raisedElevatorPosition = extendedPositionTarget1.position;
            isElevator = true;
        }

        if (linkedPlatform)
            linkePlatformScript = linkedPlatform.GetComponent<MovingPlatfromScript>();
    }

    // Update is called once per frame
    void Update()
    {

        switch(currently)
        {
            case MovingPlatformState.InWall:

               
              
                break;

            case MovingPlatformState.Extended:

                if (!staysExtended)
                {
                    timer += Time.deltaTime;
                    if (timer >= extendtedTime)
                    {
                        currently = MovingPlatformState.ReturningToWall;
                        timer = 0;
                    }
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

            case MovingPlatformState.isElevator:



                break;

                
        }
        
    }

    internal void startPlatformMovement()
    {
        if (currently == MovingPlatformState.InWall)
        {
            currently = MovingPlatformState.GoingOut;
            timer = 0;
            if (linkePlatformScript)
                linkePlatformScript.startPlatformMovement();

        }
    }
}
