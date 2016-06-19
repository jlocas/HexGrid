using System.Collections;

public enum SURFACE{
	DIRT,
	GRASS,
	TALLGRASS,
	STONE
}

public class Tile {

	int x, z;
	float y;

	public int X{
		get{
			return x;
		}
	}

	public float Y{
		get{
			return y;
		}
	}

	public int Z{
		get{
			return z;
		}
	}

	SURFACE surface;

	public Tile(SURFACE s, int posX, float posY, int posZ){
		surface = s;
		x = posX;
		y = posY;
		z = posZ;
	}

	public Tile(int posX, float posY, int posZ){
		surface = SURFACE.GRASS;
		x = posX;
		y = posY;
		z = posZ;
	}

	public Tile(int posX, int posZ){
		surface = SURFACE.GRASS;
		x = posX;
		y = 0f;
		z = posZ;
	}

}
