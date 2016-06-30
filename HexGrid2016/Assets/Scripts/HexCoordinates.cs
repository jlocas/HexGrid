using UnityEngine;

[System.Serializable]
public struct HexCoordinates {
	
	public int X { get; private set; }

	public int Y {
		get {
			return -X - Z;
		}
	}

	public int Z { get; private set; }
	
	public HexCoordinates (int x, int z) {
		X = x;
		Z = z;
	}

	// SHIFT FROM AND TO ARRAY: shifting coordinates value to fit into an array
	// in which there is no negative coordinate
	public static HexCoordinates ShiftToArray(int x, int z, int radius){
		return new HexCoordinates(x + radius, z + radius);
	}

	public static HexCoordinates ShiftFromArray(int x, int z, int radius){
		return new HexCoordinates(x + radius, z + radius);
	}

	/*
	public static HexCoordinates FromOffsetCoordinates (int x, int z) {
		return new HexCoordinates(x, z);
	}*/

	public override string ToString () {
		return "(" +
			X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + ")";
	}
	
	public string ToStringOnSeparateLines () {
		return X.ToString() + "\n" + Z.ToString();
		//return X.ToString() + "\n" + Y.ToString() + "\n" + Z.ToString();
	}

	public static HexCoordinates FromPosition (Vector3 position) {
		float x = position.x / (HexMetrics.innerRadius * 2f);
		float y = -x;

		float offset = position.z / (HexMetrics.outerRadius * 3f);
		x -= offset;
		y -= offset;

		int iX = Mathf.RoundToInt(x);
		int iY = Mathf.RoundToInt(y);
		int iZ = Mathf.RoundToInt(-x -y);
		
		if (iX + iY + iZ != 0) {
			float dX = Mathf.Abs(x - iX);
			float dY = Mathf.Abs(y - iY);
			float dZ = Mathf.Abs(-x -y - iZ);
			
			if (dX > dY && dX > dZ) {
				iX = -iY - iZ;
			}
			else if (dZ > dY) {
				iZ = -iX - iY;
			}
		}
		
		return new HexCoordinates(iX, iZ);
	}

}