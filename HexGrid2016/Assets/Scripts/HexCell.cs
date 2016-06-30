using UnityEngine;
using System.Collections;

public class HexCell {

	Vector3 center = new Vector3(0f,0f,0f);

	public HexCoordinates coordinates;
	public Color color;

	public Vector3 Center{
		get{
			return center;
		}
	}

	public HexCell (int x, int z){

		center.x = (x + z * 0.5f) * (HexMetrics.innerRadius * 2f);
		center.y = 0;
		center.z = z * (HexMetrics.outerRadius * 1.5f);
		coordinates = new HexCoordinates(x, z);
		color = Color.white;
	}

}
