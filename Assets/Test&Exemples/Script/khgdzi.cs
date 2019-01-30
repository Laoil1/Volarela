// using UnityEditor;
// using UnityEngine;
// using System.Collections;

// // Creates an instance of a primitive depending on the option selected by the user.
// public class ck : EditorWindow
// {
// 	public string[] options = new string[] {"Pedro", "René", "Gontran"};

// 	[SerializeField]
// 	public int ouais;

// 	public int index = 0;
// 	[MenuItem("Volarela/Perso")]
// 	static void Init()
// 	{
// 		EditorWindow window = GetWindow(typeof(ck));
// 		window.Show();
// 	}

// 	void OnGUI()
// 	{
// 		index = EditorGUILayout.Popup(index, options);
// 		if (GUILayout.Button("Create"))
// 			InstantiatePrimitive();
// 	}

// 	void InstantiatePrimitive()
// 	{
// 		switch (index)
// 		{
// 		case 0:
// 			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
// 			cube.transform.position = Vector3.zero;
// 			break;
// 		case 1:
// 			GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
// 			sphere.transform.position = Vector3.zero;
// 			break;
// 		case 2:
// 			GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
// 			plane.transform.position = Vector3.zero;
// 			break;
// 		default:
// 			Debug.LogError("Unrecognized Option");
// 			break;
// 		}
// 	}
// }
