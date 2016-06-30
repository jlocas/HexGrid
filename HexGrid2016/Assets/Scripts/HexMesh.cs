using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class HexMesh {

	HexCell[,] cells;

	MeshFilter meshFilter;
	MeshRenderer meshRenderer;
	MeshCollider meshCollider;


	Mesh mesh;
	List<Vector3> vertices;
	List<int> triangles;
	List<Color> colors;

	public HexMesh(HexCell[,] cellsArray, MeshFilter mfilter, MeshRenderer mrenderer, MeshCollider mcollider){

		cells = cellsArray;

		meshFilter = mfilter;
		meshRenderer = mrenderer;
		meshCollider = mcollider;
		meshFilter.mesh = mesh = new Mesh();

		mesh.name = "Hex Mesh";
		vertices = new List<Vector3>();
		triangles = new List<int>();
		colors = new List<Color>();

		MakeTriangles(cells);

		meshCollider.sharedMesh = mesh;

		
	}

	void AddTriangle (Vector3 v1, Vector3 v2, Vector3 v3) {
		int vertexIndex = vertices.Count;
		vertices.Add(v1);
		vertices.Add(v2);
		vertices.Add(v3);
		triangles.Add(vertexIndex);
		triangles.Add(vertexIndex + 1);
		triangles.Add(vertexIndex + 2);
	}

	public void MakeTriangles (HexCell[,] cells) {
		mesh.Clear();
		vertices.Clear();
		triangles.Clear();
		colors.Clear();

		/*
		foreach(HexCell cell in cells){
			MakeTriangles(cell);
		}*/

		for (int i=0; i<cells.GetLength(0); i++){
			for (int j=0; j<cells.GetLength(1); j++){
				if (cells[i,j] != null){
					MakeTriangles(cells[i,j]);
				}
			}
		}

		mesh.vertices = vertices.ToArray();
		mesh.triangles = triangles.ToArray();
		mesh.colors = colors.ToArray();

		mesh.RecalculateNormals();


	}

	void MakeTriangles (HexCell cell){
		Vector3 center = cell.Center;
		for(int i=0; i<6; i++){
			AddTriangle(
				center,
				center + HexMetrics.corners[i],
				center + HexMetrics.corners[i + 1]
				);
			AddTriangleColor(cell.color);
		}
	}

	void AddTriangleColor (Color color) {
		colors.Add(color);
		colors.Add(color);
		colors.Add(color);
	}

	public void Clear(){
		Array.Clear(cells, 0, cells.Length);
		//DEJA DANS MAKETRIANGLES()
		//vertices.Clear();
		//triangles.Clear();
		//mesh.Clear();
	}
}


