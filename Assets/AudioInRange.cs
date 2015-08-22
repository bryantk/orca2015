using UnityEngine;
using System.Collections;

public class AudioInRange : MonoBehaviour {

	public bool delete = false;
	private bool canPlay = true;

	private AudioSource myAudio;

	void Start() {
		myAudio = GetComponent<AudioSource>();
	}
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player" && canPlay) {
			myAudio.Play();
			if (delete) {
				canPlay = false;
				Invoke("deleter", 6);
			}
		}
	}

	void deleter() {
		myAudio.Stop();
		Destroy(gameObject);
	}

	void OnTriggerExit(Collider other) {
		if(other.tag == "Player" && canPlay) {
			myAudio.Stop();
		}
	}
}
