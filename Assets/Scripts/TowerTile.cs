using UnityEngine;
using System.Collections;

public class TowerTile : MonoBehaviour {
	
	private Color initialColor;
	
	// Use this for initialization
	void Start () {
		initialColor = renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseOver() {
		renderer.material.color = Color.green;
	}
	 
	void OnMouseExit() {
		renderer.material.color = initialColor;
	}
}
