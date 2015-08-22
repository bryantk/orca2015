using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ToggleText : MonoBehaviour {

	public string OnText;
	public string OffText;
	public bool state = true;

	private Text uiText;

	// Use this for initialization
	void Start () {
		uiText = GetComponent<Text>();
		SetText();
	}
	
	private void SetText() {
		if (state)
			uiText.text = OnText;
		else
			uiText.text = OffText;
	}

	public void Toggle(){
		state =! state;
		SetText();
	}

	public void SetState(bool myState) {
		uiText = GetComponent<Text>();
		state = myState;
		SetText();
	}
}
