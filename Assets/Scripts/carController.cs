using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    public Vector3 offset;
    public float speed;
    tankController tankC;
    carManager carMan;
    public GameObject particle_system;
    
    void Start()
    {
        tankC = GameObject.Find("Tank").GetComponent<tankController>();
        carMan = GameObject.Find("carsManager").GetComponent<carManager>();
    }
    
    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "shell")
        {
            //GameObject[] allCars = carMan.cars;
            //Debug.Log(allCars.Length +":"+ gameObject.tag);
            
            foreach(GameObject dc in carMan.destroyed_cars)
            {
                if(dc.tag == gameObject.tag)
                {
                    Vector3 newPos = new Vector3(transform.position.x + offset.x , transform.position.y + offset.y, transform.position.z+offset.z );
                    GameObject new_dc = Instantiate(dc,newPos,transform.rotation);
		    Destroy(new_dc,8);
                    Instantiate(particle_system,newPos,Quaternion.identity);
                    Destroy(gameObject);
                    tankC.score++;
                    break;
                }
            }
        }
    }
   
   void FixedUpdate()
   {
       transform.position += speed * transform.forward;
       
       if(transform.position.z < carMan.endPos.position.z)
       {
           tankC.lost();
       }
   }
}
