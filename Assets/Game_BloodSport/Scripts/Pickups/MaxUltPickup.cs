﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxUltPickup : MonoBehaviour {

private BS_Ultimate ultimate;
	void OnTriggerEnter(Collider other){
		
		Debug.Log("ult ball");

		ultimate = other.GetComponent<BS_Ultimate>();
		if(ultimate == null){
			return;
		}else{
			Debug.Log(ultimate == null);
			ultimate.MaxOut(100);
			Destroy(gameObject);
		}
	}	
}
