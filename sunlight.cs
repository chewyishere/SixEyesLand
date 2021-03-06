﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class sunlight : MonoBehaviour {
	static string url = "http://ec2-54-148-235-108.us-west-2.compute.amazonaws.com:2000/sentiment.txt";
	private WWW www;
	public float positive_average;
	public float previous_average;
	//public GameObject Sentiment;
	//positive_average;
	
	void Start () {
		light.intensity = 1F;
	}
	
	
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		
		// The text that will be retrieve will have the following form:
		// TEXT ------- \t POSITIVE_INDEX
		
		// check for errors
		if (www.error == null) {
			previous_average = positive_average;
			positive_average = Convert.ToSingle (www.text);
			
		}     
		
	}


	void Update () {
		
		if (Time.frameCount % 25 == 0) {
			www = new WWW (url);
			StartCoroutine(WaitForRequest(www));
			Debug.Log (positive_average);
		}

	    
		if( previous_average  < positive_average )

			light.intensity += 0.2F;

		if( previous_average  > positive_average )
			light.intensity -= 0.2F;

		if( light.intensity  > 1.6F )

			light.intensity  = 1.6F;
	}
}
