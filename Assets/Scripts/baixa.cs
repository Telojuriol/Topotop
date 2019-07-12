using UnityEngine;
using System.Collections;

public class baixa : MonoBehaviour {
    public float speed = 5;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,-speed);
	}
	
	// Update is called once per frame

}
