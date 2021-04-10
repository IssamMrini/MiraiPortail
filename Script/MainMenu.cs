using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
 
	
    public string lvltoload;

	public GameObject settingsWindow;

 	public void StartGame(){
 		SceneManager.LoadScene(lvltoload);

 	}

 	public void ReglesOption(){
 		settingsWindow.SetActive(true);
 		
 	}

 	public void CloseReglesOption(){
 		settingsWindow.SetActive(false);
 		
 	}


 	public void Quit(){
 		Application.Quit();
 		
 	}
}