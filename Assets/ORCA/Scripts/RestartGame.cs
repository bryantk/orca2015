using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour {

	public void Restart() {
		Application.LoadLevel("Intro");
	}
}
