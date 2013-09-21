using UnityEngine;
using System.Collections;

public class DomeReached : MonoBehaviour {
	
	private string _liferock = "Rock";
	private int _numliveslost = 1;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	void OnCollisionEnter(Collision other){
		
		Destroy(other.gameObject);
		GameObject child = GameObject.Find("Rock"+_numliveslost);
		Destroy(child);
		_numliveslost++;
		
		
	}
}
