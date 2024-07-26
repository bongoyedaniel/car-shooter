using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuSystem : MonoBehaviour
{
	public scoreSystem scoresystem;
	public string name = "cars";

    void Start()
    {
        GetComponent<Text>().text = "Total Cars Destroyed :"+scoresystem.load(name) ;
    }
	
	public void loadScene(string name)
	{
		SceneManager.LoadScene(name);
	}

}
