using UnityEngine;
using System.Collections;

public class Boom : MonoBehaviour {

	public GameObject target;

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			Destroy(target);
		}
	}

}
