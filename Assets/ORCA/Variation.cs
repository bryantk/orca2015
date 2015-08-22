using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Variation : MonoBehaviour {

	public Vector3 Scale = new Vector3(1,1,1);
	public Vector3 Rotation = new Vector3(1,1,1);

	private bool set = false;

	// Use this for initialization
	void Start () {
		Vector3 myScale = new Vector3(1,1,1);
		myScale.x += Random.Range(-Scale.x, Scale.x);
		myScale.y += Random.Range(-Scale.y, Scale.y);
		myScale.z += Random.Range(-Scale.z, Scale.z);
		transform.localScale = myScale;

		Vector3 myRotation = new Vector3(1,1,1);
		myRotation.x += Random.Range(-Rotation.x, Rotation.x);
		myRotation.y += Random.Range(-Rotation.y, Rotation.y);
		myRotation.z += Random.Range(-Rotation.z, Rotation.z);
		transform.localRotation = Quaternion.Euler(myRotation);
	}
	
	// Update is called once per frame
	void Update () {
		if (set)
			return;
		Vector3 myScale = new Vector3(1,1,1);
		myScale.x += Random.Range(-Scale.x, Scale.x);
		myScale.y += Random.Range(-Scale.y, Scale.y);
		myScale.z += Random.Range(-Scale.z, Scale.z);
		transform.localScale = myScale;
		
		Vector3 myRotation = new Vector3(1,1,1);
		myRotation.x += Random.Range(-Rotation.x, Rotation.x);
		myRotation.y += Random.Range(-Rotation.y, Rotation.y);
		myRotation.z += Random.Range(-Rotation.z, Rotation.z);
		transform.localRotation = Quaternion.Euler(myRotation);
		set = true;
	}
}
