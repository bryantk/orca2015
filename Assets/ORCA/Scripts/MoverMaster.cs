using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoverMaster : MonoBehaviour {

	private Transform head;
	private Rigidbody rigidbody;
	private Cardboard cb;
	public bool walk = false;
	
	public float speed;

	[Header("important")]
	public bool usePedometer = true;
	public bool inspectingItem = false;
	public AudioSource foot_steps;

	[Header("GUIs")]
	public GameObject Input_Canvas;
	public Text note_text;

	[Header("Pedometer")]
	public float loLim = 0.005f; // level to fall to the low state 
	public float hiLim = 0.1f; // level to go to high state (and detect step) 
	public float fHigh = 10.0f; // noise filter control - reduces frequencies above fHigh private 
	public float curAcc = 0f; // noise filter 
	public float fLow = 0.1f; // average gravity filter control - time constant about 1/fLow 
	public int wait_time = 30;

	private float avgAcc = 0f;
	private bool stateH = false; // comparator state
	private int steps = 0; // step counter - counts when comp state goes high private 
	private int old_steps = 0;
	private int counter = 30;

	private int inspectResetDelay = 0;
	private Master master;

	void Awake() {
		avgAcc = Input.acceleration.magnitude; // initialize avg filter
		master = Master.instance;

	}
	
	void PedometerUpdate() {
		if (!usePedometer)
			return;
		if (counter > 0) {
			counter--;
			return;
		}
		counter = wait_time;
		if (steps != old_steps)
			walk = true;
		else
			walk = false;
		old_steps = steps;
	}
	
	void FixedUpdate(){ // filter input.acceleration using Lerp
		curAcc = Mathf.Lerp(curAcc, Input.acceleration.magnitude, Time.deltaTime * fHigh);
		avgAcc = Mathf.Lerp(avgAcc, Input.acceleration.magnitude, Time.deltaTime * fLow);
		float delta = curAcc-avgAcc; // gets the acceleration pulses
		if (!stateH){ // if state == low...
			if (delta>hiLim){ // only goes high if input > hiLim
				stateH = true; 
				steps++; // count step when comp goes high 
				foot_steps.Play();
				print ("step");
			} 
		} else { 
			if (delta<loLim){ // only goes low if input < loLim 
				stateH = false; 
			} 
		} 
	}





	// Use this for initialization
	void Start () {
		head = transform.GetChild(0);
		rigidbody = GetComponent<Rigidbody>();
		cb = GetComponent<Cardboard>();
	}
	
	// Update is called once per frame
	void Update () {
		if (inspectResetDelay > 0)
			inspectResetDelay--;
		float s = 0;
		if (Application.isEditor && Input.GetKey(KeyCode.W)) {
			s = speed;
		}


		if (walk)
			s = speed;

		float angle = head.localEulerAngles.y;
		Vector3 lDirection = new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(Mathf.Deg2Rad * angle)) * s;
		lDirection.y = rigidbody.velocity.y;
		rigidbody.velocity = lDirection;


		if (cb.CardboardTriggered && !usePedometer && !inspectingItem && inspectResetDelay <= 0) {
			walk = !walk;
		}

		PedometerUpdate();
	}

	public void SetNoteInUse(string text) {
		Input_Canvas.SetActive(true);
		note_text.text = text;
		if (!usePedometer)
			walk = false;
	}

	public void ClearItemInUse() {
		Input_Canvas.SetActive(false);
		inspectingItem = false;
		inspectResetDelay = 20;
		Interactable.FreeInUse();
		if (!usePedometer)
			walk = false;
		print ("Item in use cleared!");
	}

	public void SetInspect(bool inspecting) {
		inspectingItem = inspecting;
	}
	public void OneOffInteract() {
		if (!usePedometer)
			walk = false;
	}
}
