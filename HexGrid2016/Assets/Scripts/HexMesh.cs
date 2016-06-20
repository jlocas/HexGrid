using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexMesh {

	TileMap map;
	HexCell[,] cells;

	MeshFilter meshFilter;
	MeshRenderer meshRenderer;

	Mesh mesh;
	List<Vector3> vertices;
	List<int> triangles;

	public HexMesh(TileMap tmap, MeshFilter mfilter, MeshRenderer mrenderer){
		map = tmap;
		meshFilter = mfilter;
		meshRenderer = mrenderer;
		meshFilter.mesh = mesh = new Mesh();

		cells = new HexCell[map.SizeX, map.SizeZ];

		mesh.name = "Hex Mesh";
		vertices = new List<Vector3>();
		triangles = new List<int>();

		for(int x=0; x<map.SizeX; x++){
			for(int z=0; z<map.SizeZ; z++){
				Tile tile = map.Tiles[x,z];
				cells[x,z] = new HexCell(tile.X, tile.Y, tile.Z);
			}
		}

		MakeTriangles();
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

	public void MakeTriangles () {
		mesh.Clear();
		vertices.Clear();
		triangles.Clear();
		for(int x=0; x<map.SizeX; x++){
			for(int z=0; z<map.SizeZ; z++){
				Vector3 center = cells[x,z].Center;

				for(int i=0; i<6; i++){
					AddTriangle(
						center,
						center + HexMetrics.corners[i],
						center + HexMetrics.corners[i + 1]
						);
				}
			}
		}
		mesh.vertices = vertices.ToArray();
		mesh.triangles = triangles.ToArray();
		mesh.RecalculateNormals();
	}

	public void Clear(){
		Array.Clear(cells, 0, cells.Length);
		vertices.Clear();
		triangles.Clear();
		mesh.Clear();
	}
}


