﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class treeanimate : MonoBehaviour {
	static string url = "http://ec2-54-148-235-108.us-west-2.compute.amazonaws.com:2000/sentiment.txt";
	private WWW www;
	public float positive_average;

	public float turnSpeed = 100f;

	public float previous_average;
	//public GameObject Sentiment;
	//positive_average;
	
	void Start () {
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

		//if(Input.GetKey(KeyCode.V))
		transform.Rotate(Vector3.right, turnSpeed * Time.deltaTime, Space.Self);

		//if(Input.GetKey(KeyCode.Equals))
		if( previous_average  < positive_average )
			turnSpeed = turnSpeed + 10f;

		//if(Input.GetKey(KeyCode.Minus))
		if( previous_average  > positive_average )
			turnSpeed = turnSpeed - 10f;

		if (turnSpeed <= 10f)
			turnSpeed = 5f;

		if (turnSpeed >= 200f)
			turnSpeed = 200f;

	
}
}