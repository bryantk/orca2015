using UnityEngine;
using System.Collections;

public class RotationLock : MonoBehaviour {

	public Transform target;
	public bool lockX = false;
	public bool lockY = false;
	public bool lockZ = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 rot = target.localRotation.eulerAngles;
		if (lockX)
			rot.x = transform.localRotation.x;
		if (lockY)
			rot.y = transform.localRotation.y;
		if (lockZ)
			rot.z = transform.localRotation.z;
		this.transform.rotation = Quaternion.Euler(rot);
	}
}
