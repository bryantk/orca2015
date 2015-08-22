using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;

public class AccTest : MonoBehaviour {

	public Text acc;
	public Text gy;

	private Cardboard cb;
	private string filePath;

	public float cldwnRate = 0.4f;

	//x = forward = gyro.z
	//y = side = gyro.x
	public float cldwn;
	private float curAcc = 0;
	private float avgAcc = 0;

	// Use this for initialization
	void Start () {
		cb = GetComponent<Cardboard>();
		if (Application.isEditor)
			filePath = Application.dataPath + "/accData.txt";
		else
			filePath = Application.persistentDataPath + "/accData.txt";
		Input.gyro.enabled = true;
		using (StreamWriter outfile = new StreamWriter(filePath, true)) {
			outfile.WriteLine("--- Begin Simulation ------");
		}
		cldwn = cldwnRate;
	}
	
	// Update is called once per frame
	void Update () {

		curAcc = Mathf.Lerp(curAcc, Input.acceleration.magnitude, Time.deltaTime * 10f);
		avgAcc = Mathf.Lerp(avgAcc, Input.acceleration.magnitude, Time.deltaTime * 0.1f);
		float delta = curAcc-avgAcc; // gets the acceleration pulses

		//string data = string.Format("({0}: ({1},{2},{3}))", Time.time, Input.acceleration.x, Input.acceleration.y, Input.acceleration.z);
		string data = string.Format("({0}: ({1},{2},{3}))", Time.time, curAcc, avgAcc, delta);
		string step = "";
		if (cb.CardboardTriggered) {
			step = "(" + Time.time.ToString() + ", step)";
		}
		using (StreamWriter outfile = new StreamWriter(filePath, true)) {
			outfile.WriteLine(data);
			if (step != "")
				outfile.WriteLine(step);
		}
	}


}
