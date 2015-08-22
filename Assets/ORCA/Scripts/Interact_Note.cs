using UnityEngine;
using System.Collections;

public class Interact_Note : Interactable {

	public string text;

	private bool WithinDistance(float units) {
		float distance = Vector3.Distance(master.transform.position, this.transform.position);
		print(distance);
		return distance <= units;
	}

	public void Use() {
		if (!WithinDistance(3)) {
			print("too far");
			return;
		}
		if (MarkInUse() ) {
			master.SetNoteInUse(text);
			master.inspectingItem = true;
		}
	}

	public void InspectIn() {
		master.inspectingItem = true;
		GetComponent<Renderer>().material.color = new Color(1,1,0,0.15f);
	}
	public void InspectOut() {
		master.inspectingItem = false;
		GetComponent<Renderer>().material.color = new Color(0.8f,0.8f,0.8f,0.2f);
	}

}
