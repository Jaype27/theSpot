﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BS_Pickup : MonoBehaviour {

	public const float MAX_HEALTH = 1000.0f;

	public float m_currentHealth;
	public GameObject ballPrefab;

	private Transform ballSpawn;


	void Start() {
		
		m_currentHealth = MAX_HEALTH;

	}

	public void TakeDamage(float damage) {
		m_currentHealth -= damage;
		Die();
	}

	public void Die() {
		Debug.Log("rip");
		if(m_currentHealth <= 0) {
			m_currentHealth = 0;
			ballSpawn = gameObject.transform;
			 
			GameObject x2ball = (GameObject)Instantiate (ballPrefab,ballSpawn.position,ballSpawn.rotation);

			Destroy(gameObject);

			// TODO: add what happens when they die
			Debug.Log(m_currentHealth);
		}
	}

	public void Heal(int amount) {
		m_currentHealth += amount;
		if(m_currentHealth > MAX_HEALTH) {
			m_currentHealth = MAX_HEALTH;
		}
	}

	 	
	void OnTriggerEnter(Collider other){
		
			Debug.Log("hit");
			TakeDamage(damage:1);
		
	}  
}

