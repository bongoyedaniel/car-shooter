using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tankController : MonoBehaviour
{
    public Transform shotPos;
    public Rigidbody projectile;
    public Transform tankTurret;
    
    public Text scoreDisplay;
    public scoreSystem score_system;
	public int score = 0,maxScore =10;
    public float shotForce = 10,rotateSpeed = 2;
    
    public GameObject wonScreen,lostScreen;
    public AudioSource fire;
    
    void Start()
    {
        Time.timeScale = 1;
    }
    
    void FixedUpdate()
    {
        if(score >= maxScore)
        {
            score_system.save("cars", score);
			wonScreen.SetActive(true);
			Time.timeScale = 0;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = "Score :" + score +"/" + maxScore;
		
		float h = Input.GetAxis("Horizontal");
		
		if(h  != 0)
			tankTurret.Rotate(0,h*rotateSpeed,0,Space.Self);
		
        if(Input.GetButtonUp("Fire1") || Input.GetKeyDown("space"))
		{
            fire.Play(0);
            
            RaycastHit hit;
            Ray ray = new Ray(shotPos.position,shotPos.forward);
        
            if (Physics.Raycast(ray, out hit,200)) {
                if(hit.collider.transform.gameObject.tag.StartsWith("car"))
                {
                    Debug.DrawRay(shotPos.position,hit.point);
                }
            }
            
			Rigidbody shotProjectile = Instantiate(projectile,shotPos.position,shotPos.rotation);
			shotProjectile.AddForce(shotPos.forward * shotForce);
            Destroy(shotProjectile.transform.gameObject,2f);
		}
    }
    
    public void lost()
    {
        score_system.save("cars", score);
        lostScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
