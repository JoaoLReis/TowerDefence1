using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {
	
	public GameObject[] successors;
	
	public bool objective = false;
	
	private Vector3 position;
	
	// Use this for initialization
	void Start () {
		position = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public Vector3 getPosition() {
		return position;	
	}
	
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Enemy") {
			if(!objective) {
				if(successors.Length != 0) {
					if(successors.Length == 1){
						other.gameObject.GetComponent<Enemy>().setTarget(successors[0]);
					} /*else {
						Debug.Log("checking");
						Debug.Log(successors.Length);
						for(int i = 0; i < successors.Length; i++) {
							if(checkPath(successors[i])) {
								other.gameObject.GetComponent<Enemy>().setTarget(successors[i]);
							}
						}
					}*/
				}
			}
		}
    }
	
	private bool checkPath(GameObject obj) {
		GameObject[] suc = obj.GetComponent<Node>().successors;
		if(obj.GetComponent<Node>().objective) {
			Debug.Log("Objective");
			return true;	
		} else {
			if(suc.Length != 0) {
				Debug.Log("sucessor");
				for(int i = 0; i < suc.Length; i++) {
					if(checkPath(suc[i])) {
						return true;	
					}
				}
			}
		}
		return false;
	}
}
