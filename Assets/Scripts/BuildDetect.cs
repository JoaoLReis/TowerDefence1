using UnityEngine;
using System.Collections;

public class BuildDetect : MonoBehaviour {
	
	public GameObject Tower0;
	
	public GameObject Tower1;
	
	public GameObject Tower2;
	
	public GameObject Tower3;
	
	private int toolbarInt = 0;
	
	private string[] toolbarStrings = {"Tower0", "Tower1", "Tower2", "Tower3"};
	
	private bool drawMenu;
	
	private RaycastHit ray;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit rayHit;
		if(!drawMenu) {
			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit)) {
				Debug.DrawLine(Camera.main.ScreenPointToRay(Input.mousePosition).origin, rayHit.point);
				if(rayHit.collider.transform.gameObject.tag == "TowerTile" && Input.GetMouseButtonDown(0)) {
					ray = rayHit;
					drawMenu = true;
				}
			}
		} else {
			if(Input.GetMouseButtonDown(1)) {
				drawMenu = false;
			}
		}
	}
	
	void OnGUI() {
		GameObject obj;
		Vector3 screenPt;
		if (drawMenu) {
			screenPt = Camera.main.WorldToScreenPoint(ray.point);
			toolbarInt = GUI.Toolbar (new Rect (screenPt.x, Screen.height - screenPt.y, 250, 30), toolbarInt, toolbarStrings);
			if(GUI.changed) {
				switch (toolbarInt)
				{
				    case 0:
				        obj = Instantiate (Tower0, ray.collider.transform.position, Quaternion.identity) as GameObject;
						drawMenu = false;
				        break;
					
				    case 1:
				        obj = Instantiate (Tower1, ray.collider.transform.position, Quaternion.identity) as GameObject;
				    	drawMenu = false;    
						break;
					
					case 2:
				        obj = Instantiate (Tower2, ray.collider.transform.position, Quaternion.identity) as GameObject;
				        drawMenu = false;
						break;
					
					case 3:
				        obj = Instantiate (Tower3, ray.collider.transform.position, Quaternion.identity) as GameObject;
				        drawMenu = false;
						break;
					
				    default:
				        break;
				}
			}
		}
	}
}
