using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public string startLevel;
	public string levelSelect;
	
	public int playerLives;
	
	public int playerHealth;
	
	public void NewGame(){
		Application.LoadLevel(startLevel);
		
		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);
		
		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
		
		PlayerPrefs.SetInt ("PlayerMaxHealth", playerHealth);
		
		PlayerPrefs.SetInt ("CurrentScore", 0);
		
		Application.LoadLevel(startLevel);
	}
	
	public void LevelSelect(){
		PlayerPrefs.SetInt ("PlayerCurrentLives", playerLives);
		PlayerPrefs.SetInt ("CurrentScore", 0);
		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
		PlayerPrefs.SetInt ("PlayerMaxHealth", playerHealth);
		Application.LoadLevel(levelSelect);
	}
	
	public void QuitGame(){
		Application.Quit();
	}

}
