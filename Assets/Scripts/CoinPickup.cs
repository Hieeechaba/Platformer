using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

	public int pointsToAdd;
	
	public GameObject coinParticles;
	
	public AudioSource coinSoundEffect;

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.GetComponent<PlayerController>() == null)
			return;
		
		ScoreManager.AddPoints(pointsToAdd);
		Instantiate (coinParticles, transform.position, transform.rotation);
		coinSoundEffect.Play ();
		Destroy (gameObject);
		
	}
}
