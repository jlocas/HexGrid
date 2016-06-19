using System.Collections;
using System;

public class TileMap {
	
	int sizeX, sizeZ;


	public int SizeX{
		get{
			return sizeX;
		}
	}
	
	public int SizeZ{
		get{
			return sizeZ;
		}
	}


	Tile[,] tiles;

	public Tile[,] Tiles{
		get{
			return tiles;
		}
	}

	public TileMap(int w, int l) {
		sizeX = w;
		sizeZ = l;
		tiles = new Tile[sizeX, sizeZ];

		for(int x=0; x<sizeX; x++){
			for(int z=0; z<sizeZ; z++){
				tiles[x,z] = new Tile(x, z);
			}
		}
	}

	public void Clear(){
		Array.Clear(tiles, 0, tiles.Length);
	}

}
