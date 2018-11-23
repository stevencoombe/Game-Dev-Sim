﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITutorial : MonoBehaviour 
{
	public bool inTrigger;
	//public GameObject Player;
	[SerializeField] private Image customImage;

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player")) 
		{
			customImage.enabled = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player")) 
		{
			customImage.enabled = false;
		}
	}
}