using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	private GameObject target;
	
	public float speed = 10;
	
	private Vector3 position;
	
	private Vector3 objective;
	
	private float distance;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		position = gameObject.transform.position;
		distance = Vector3.Distance(position, objective);
		transform.LookAt(new Vector3(objective.x, position.y, objective.z));
	    transform.position = Vector3.Lerp (position, objective, Time.deltaTime* speed/distance);
    }
	
	public void setTarget(GameObject trgt) {
		target = trgt;
		objective = trgt.transform.position;
	}
	
	public GameObject getTarget() {
		return target;
	}
}
