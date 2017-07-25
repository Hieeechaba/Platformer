﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerEnemyMover : MonoBehaviour {

	private PlayerController thePlayer;
	
	public float moveSpeed;
	
	public float playerRange;
	
	public LayerMask playerLayer;
	
	public bool playerInRange;
	
	public bool facingAway;
	public bool followOnLookAway;
	
	public bool flipOver;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
		playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);
		
		if(!followOnLookAway)
		{
			if(playerInRange)
			{
				transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);
				return;
			}
		}
		
		if((thePlayer.transform.position.x < transform.position.x && thePlayer.transform.localScale.x < 0) || (thePlayer.transform.position.x > transform.position.x && thePlayer.transform.localScale.x > 0))
		{
			facingAway = true;
			transform.localScale = new Vector3(1f, 1f, 1f);
		}else {
			facingAway = false;
			transform.localScale = new Vector3(-1f, 1f, 1f);
		}
		
		if(playerInRange && facingAway)
			{
				transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);
			}
		
	}
	
	void OnDrawGizmosSelected () {
		
		Gizmos.DrawSphere(transform.position, playerRange);
		
	}
}
