using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {

	public static Interactable inUse = null;
	protected MoverMaster master;

	public virtual void Awake () {
		master = GameObject.FindObjectOfType<MoverMaster>();
	}


	public bool MarkInUse() {
		if (inUse) {
			Debug.LogWarning(inUse.name + " already in use!");
			return false;
		}
		inUse = this;
		return true;
	}

	public static void FreeInUse() {
		inUse = null;
	}

	
	public virtual void InspectIn() {
		master.inspectingItem = true;
	}
	public virtual void InspectOut() {
		master.inspectingItem = false;
	}
	public virtual void SetInspect(bool inspecting) {
		master.inspectingItem = inspecting;
	}
}
