using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePoisonScript : MonoBehaviour
{
    float Health = 100;

    float currentPoisonRate, maxPoisonRate, TotalPoisonTime =20 ;
    float currentTotalPoisonTime;
    private readonly float startPoisonRate =1;
    bool isPoisoned = false;
    private float poisonIncreasRate =1;

    public float MaxPoisonRate = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            startPoison();


        if (isPoisoned)
        {
            Health -= Mathf.Clamp( currentPoisonRate, 0,MaxPoisonRate) * Time.deltaTime;
            currentPoisonRate += poisonIncreasRate * Time.deltaTime;
            if (currentPoisonRate >= (MaxPoisonRate + poisonIncreasRate))  // maximum rate of poison for 1 second
                currentPoisonRate = startPoisonRate;

            currentTotalPoisonTime += Time.deltaTime;

            if (currentTotalPoisonTime > TotalPoisonTime)
            {
                isPoisoned = false;
            }
        }


        print("Current Health " + Health.ToString() + " Poison Rate " + currentPoisonRate.ToString());
    }


    internal void startPoison()
    {
        currentPoisonRate = startPoisonRate;
        currentTotalPoisonTime = 0;
        isPoisoned = true;



    }
}

