using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	private GameObject target;
	
	public float speed = 30; 
	
	private Vector3 position;
	
	private Vector3 objective;
	
	private float distance;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		position = transform.position;
		if(target != null) {
			//distance = Vector3.Distance(position, objective);
			transform.LookAt(new Vector3(objective.x, position.y, objective.z));
		    transform.position = Vector3.MoveTowards(position, new Vector3(objective.x, position.y, objective.z), speed);
		}
	}
	
	public void setTarget(GameObject trgt) {
		target = trgt;
		objective = trgt.transform.position;
	}
	
	public GameObject getTarget() {
		return target;
	}
}
