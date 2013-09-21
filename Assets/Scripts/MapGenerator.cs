using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {
	
	public GameObject TowerTile;
	
	public GameObject PathTile;
	
	public GameObject Node;
	
	public GameObject Enemy;
		
	public GameObject Base;
	
	private Vector3 StartPos;
	
	private Vector3 EndPos;
	
	// Use this for initialization
	void Start () {
		Vector3 pos = transform.position;
		
		GameObject node;
		
		// 0-> four 5x size cubes 
		// 1-> one 10x size tile
		// 2-> start area
		// 3 above and beyond served for path node placing and naming
		int[,] array2D = new int[,] { { 0, 0, 0, 0, 0,  0, 0,  0, 0, 0,  0, 0 },
									  { 0, 0, 0, 0, 0,  0, 0,  0, 0, 0,  2, 0 },
									  { 0, 0, 0, 0, 0,  0, 0,  0, 0, 0,  1, 0 }, 
									  { 0, 0, 8, 1, 1,  1, 7,  0, 4, 1,  3, 0 }, 
									  { 0, 0, 1, 0, 0,  0, 6,  1, 5, 0,  0, 0 },
									  { 0, 0, 1, 0, 0,  0, 0,  0, 0, 0,  0, 0 }, 
									  { 0, 0, 1, 0, 11, 1, 1,  1, 1, 12, 0, 0 },
									  { 0, 0, 1, 0, 1,  0, 0,  0, 0, 1,  0, 0 },
									  { 0, 0, 1, 0, 1,  0, 0,  0, 0, 1,  0, 0 },
									  { 0, 0, 1, 0, 1,  0, 15, 0, 0, 1,  0, 0 },
									  { 0, 0, 9, 1, 10, 0, 14, 1, 1, 13, 0, 0 },
									  { 0, 0, 0, 0, 0,  0, 0,  0, 0, 0,  0, 0 }, 
									  { 0, 0, 0, 0, 0,  0, 0,  0, 0, 0,  0, 0 }, };
		
		for (int i = 0; i <= 12; i++) {
			for (int z = 0; z <= 11; z++) {
				if (array2D[i,z] == 0) {
					Instantiate (TowerTile, new Vector3(pos.x - 5, pos.y, pos.z - 5), Quaternion.identity);
					Instantiate (TowerTile, new Vector3(pos.x + 5, pos.y, pos.z + 5), Quaternion.identity);
					Instantiate (TowerTile, new Vector3(pos.x + 5, pos.y, pos.z - 5), Quaternion.identity);
					Instantiate (TowerTile, new Vector3(pos.x - 5, pos.y, pos.z + 5), Quaternion.identity);
				} else {
					if(array2D[i,z] == 1) {
						Instantiate (PathTile, pos, Quaternion.identity);
					} else {
						if(array2D[i,z] == 2) {
							Instantiate (PathTile, pos, Quaternion.identity);
							node = Instantiate (Node, new Vector3(pos.x, pos.y + 3, pos.z), Quaternion.identity) as GameObject;
							node.name = ""+(array2D[i,z] - 1);
							// note: map is still being generated, so only the start position is recorded for later use
							StartPos = pos;
						} else {
							Instantiate (PathTile, pos, Quaternion.identity);
							node = Instantiate (Node, new Vector3(pos.x, pos.y + 3, pos.z), Quaternion.identity) as GameObject;
							node.name = ""+(array2D[i,z] - 1);
							//needs to be a constant or find a better way to define the end position
							if(array2D[i,z] == 15) {
								EndPos = pos;
							}
						}
					}
				}
				pos = new Vector3(pos.x, pos.y, pos.z - 20);
			}
			pos = new Vector3(pos.x - 20, pos.y, transform.position.z);
		}
		//2Dimentional array limits need to be constants instead of 12/11
		Instantiate(Base, new Vector3(EndPos.x, EndPos.y + 3, EndPos.z), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		Instantiate (Enemy, new Vector3(StartPos.x, StartPos.y + 3, StartPos.z), Quaternion.identity);
	}
}
