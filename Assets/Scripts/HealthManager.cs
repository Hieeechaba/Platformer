using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	public int maxPlayerHealth;

	public static int playerHealth;
	
	Text text;
	
	private LevelManager levelManager;
	
	public bool isDead;
	
	private LifeManager lifeSystem;
	
	private TimeManager theTime;


	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		
		//playerHealth = maxPlayerHealth;
		playerHealth = PlayerPrefs.GetInt("PlayerCurrentHealth");
		
		theTime = FindObjectOfType<TimeManager>();
		
		levelManager = FindObjectOfType<LevelManager>();
		
		lifeSystem = FindObjectOfType<LifeManager>();
		
		isDead = false;
		
		theTime.ResetTime();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerHealth <= 0 && !isDead)
		{
		playerHealth = 0;
		levelManager.RespawnPlayer();
		lifeSystem.TakeLife();
		isDead = true;
		theTime.ResetTime();
		}
		
		text.text = "" + playerHealth;
		
	}
	
	public static void HurtPlayer(int damageToGive)
	{
		playerHealth -= damageToGive;
		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
	}
	
	public void FullHealth()
	{
		//playerHealth = maxPlayerHealth;
		playerHealth = PlayerPrefs.GetInt("PlayerMaxHealth");
	}
	
	public static void KillPlayer()
	{
		playerHealth = 0;
	}
}
