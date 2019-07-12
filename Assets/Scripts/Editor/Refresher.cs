using UnityEngine;
using UnityEditor;
using System.Collections;

[InitializeOnLoad]
public class Refresher : MonoBehaviour {

    static Refresher()
    {
        EditorApplication.update += Update;
    }
    // Use this for initialization
    static void Update()
    {
        AssetDatabase.Refresh();

    }
	
	// Update is called once per frame
}
