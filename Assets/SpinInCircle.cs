using UnityEngine;
using System.Collections;

public class SpinInCircle : MonoBehaviour {
	
	
	private float movement = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.LookAt(GameObject.Find("CenterOfCircleMarker").GetComponent<Transform>());
		transform.Translate(Time.deltaTime, 0,0);
		
		
	}
}
