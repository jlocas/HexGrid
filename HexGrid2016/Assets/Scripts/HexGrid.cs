using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class HexGrid : MonoBehaviour {


	[SerializeField]
	// RAYON DE LA GRILLE HEXAGONALE
	int radius;
	//public Color defaultColor = Color.white;
	//public Color touchedColor = Color.magenta;


	// POUR ÉTIQUETTES DE COORDONNÉES DES HEX TILES
	public Text cellLabelPrefab;
	Canvas gridCanvas;



	// POUR AFFICHER LA HEX GRID
	HexMesh hexMesh;
	HexCell[,] cellsArray;
	//List<HexCell> cells = new List<HexCell>();
	HexCell tempcell;

	//public HexCell cellPrefab;
	//int cellsQty;



	// Use this for initialization
	void Start () {
		gridCanvas = GetComponentInChildren<Canvas>();
		Generate ();
	}

	public void Generate(){

		GenerateGrid();
		GenerateMesh();
	}


	// Update is called once per frame
	void Update () {

	}


	void GenerateGrid(){


		//cellsQty = (2*radius+1) * (2*radius+1) - 2*factorial(radius);

		cellsArray = new HexCell[2*radius+1, 2*radius+1];


		for(int dx = -radius; dx <= radius; dx++){
			for(int dy = -radius; dy <= radius; dy++){
				for(int dz = -radius; dz <= radius; dz++){
					if ( (dx + dy + dz) == 0){

						CreateCell (dx, dz);
					}
				}
			}
		}


	}


	void CreateCell(int dx, int dz){

		//Debug.Log("Creating cell " + dx + "," + dz);
		tempcell = new HexCell(dx, dz);
		cellsArray[dx+radius,dz+radius] = tempcell;

		//cells.Add(tempcell);


		// AFFICHER LES ÉTIQUETTES DE COORDONNÉES: aucune fonction logique
		Text label = Instantiate<Text>(cellLabelPrefab);
		label.rectTransform.SetParent(gridCanvas.transform, false);
		label.rectTransform.anchoredPosition =
			new Vector2(tempcell.Center.x, tempcell.Center.z);
		label.text = tempcell.coordinates.ToStringOnSeparateLines();
	}
	
	
	void GenerateMesh(){
		
		if(hexMesh != null){
			hexMesh.Clear();
			Debug.Log("Clearing the mesh!");
		}

		hexMesh = new HexMesh(cellsArray, GetComponent<MeshFilter>(), GetComponent<MeshRenderer>(), GetComponent<MeshCollider>() );
	}

	int factorial(int num){
		int answer = 0;

		if (num == 0) return 0;

		for(int i = 1; i < num; i++){
			answer = answer + i;
		}

		return answer;
	}


	
	public void ColorCell (Vector3 position, Color color) {
		position = transform.InverseTransformPoint(position);
		HexCoordinates coordinates = HexCoordinates.FromPosition(position);
		Debug.Log("touched at " + coordinates.ToString());
		//int index = coordinates.X + coordinates.Z * width + coordinates.Z / 2;
		HexCell cell = cellsArray[coordinates.X+radius, coordinates.Z+radius];
		cell.color = color;
		hexMesh.MakeTriangles(cellsArray);

	}



}
