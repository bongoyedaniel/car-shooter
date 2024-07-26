using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

[System.Serializable]
public class scoreSystem : MonoBehaviour {
	
	public void save(string name,int value){
		PlayerPrefs.SetInt(name, load(name) + value);
		PlayerPrefs.Save();
	}

	public int load(string name)
	{
		return PlayerPrefs.GetInt(name,0);
	}
 }