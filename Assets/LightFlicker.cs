using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

	public float min=1;
	public float max=2;

	private float random;
	private Light light;

	void Start()
	{
		random = Random.Range(0.0f, 65535.0f);
		light = GetComponent<Light>();
	}
	
	void Update()
	{
		float noise = Mathf.PerlinNoise(random, Time.time);
		light.intensity = Mathf.Lerp(min, max, noise);
	}
}
