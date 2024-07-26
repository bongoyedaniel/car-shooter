using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class carManager : MonoBehaviour
{
    public GameObject[] cars;
    public GameObject[] destroyed_cars;
    
    public Transform[] startPos;
    public Transform endPos;
    
    public float waitTime=0,maxWaitTime = 5;
    
    public float carMaxTime =20;
    
    tankController tankC;
    
    void Start()
    {
        tankC = GameObject.Find("Tank").GetComponent<tankController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        waitTime -= Time.deltaTime;
        
        if(waitTime <= 0)
        {
            GameObject newCar = Instantiate(cars[UnityEngine.Random.Range(0,cars.Length)],startPos[UnityEngine.Random.Range(0,startPos.Length)].position,startPos[0].rotation);
            try{
                Destroy(newCar,carMaxTime);
            }catch(Exception e)
            {
                Debug.Log(e);
            }
            
            waitTime = maxWaitTime;
        }
    }
}
