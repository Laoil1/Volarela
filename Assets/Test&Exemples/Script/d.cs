// // EditorScript that quickly searches for a help page
// // about the selected Object.
// //
// // If no such page is found in the Manual it opens the Unity forum.

// using UnityEditor;
// using UnityEngine;
// using System.Collections;

// public class ExampleClass : EditorWindow
// {
//     public Sprite source;

//     public delegate void MyDelegate(float f);
//     public event MyDelegate myEvent;
    


//     void SomeFunc(float f)
//     {

//     }


//     [MenuItem("Example/ObjectField Example ")]
//     static void Init()
//     {
//         var window = GetWindowWithRect<ExampleClass>(new Rect(0, 0, 165, 100));
//         window.Show();


        
//     }

//     void OnGUI()
//     {

//         float f = 3.0f;

//         if (myEvent != null)
//             myEvent(f);


//         EditorGUILayout.BeginHorizontal();
//         source = EditorGUILayout.ObjectField("Source :",source, typeof(Sprite), true) as Sprite;
//         EditorGUILayout.EndHorizontal();

//         if (GUILayout.Button("Search!"))
//         {
//             if (source == null)
//                 ShowNotification(new GUIContent("No object selected for searching"));
//             else 
// 				Debug.Log(source);
// 		}
//     }
// }	