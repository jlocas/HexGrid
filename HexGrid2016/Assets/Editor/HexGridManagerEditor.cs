using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(HexGridManager))]
public class HexGridManagerEditor : Editor {

	public override void OnInspectorGUI(){
		DrawDefaultInspector();

		HexGridManager script = (HexGridManager)target;
		if(GUILayout.Button ("Generate!")){
			script.Generate();
		}
	}

}
