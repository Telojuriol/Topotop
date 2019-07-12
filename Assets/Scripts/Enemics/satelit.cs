using UnityEngine;
using System.Collections;

public class satelit : MonoBehaviour {
    private float x = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rotate = new Vector3(0,Time.deltaTime * 100,0);
        transform.Rotate(rotate);

    }
}
