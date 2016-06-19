using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexGridManager : MonoBehaviour {


	[SerializeField]
	int sizeX, sizeZ;

	HexMesh hexMesh;



	public TileMap map;

	// Use this for initialization
	void Start () {
		Generate();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Generate(){
		if(map != null){
			map.Clear();
			Debug.Log("Clearing the map!");
		}

		if(hexMesh != null){
			hexMesh.Clear();
			Debug.Log("Clearing the mesh!");
		}



		map = new TileMap(sizeX, sizeZ);
		hexMesh = new HexMesh(map, GetComponent<MeshFilter>(), GetComponent<MeshRenderer>() );
	}
}
