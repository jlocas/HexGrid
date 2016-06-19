using UnityEngine;
using System.Collections;

public class HexCell {

	Vector3 center = new Vector3(0f,0f,0f);

	public Vector3 Center{
		get{
			return center;
		}
	}

	public HexCell (int x, float y, int z){

		center.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f);
		center.y = y;
		center.z = z * (HexMetrics.outerRadius * 1.5f);
	}

}
