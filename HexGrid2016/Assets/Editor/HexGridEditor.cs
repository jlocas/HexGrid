using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(HexGrid))]
public class HexGridEditor : Editor {

	public override void OnInspectorGUI(){
		DrawDefaultInspector();

		HexGrid script = (HexGrid)target;
		if(GUILayout.Button ("Generate!")){
			script.Generate();
		}
	}

}
