using UnityEngine;
using System.Collections;

public class escarbat : MonoBehaviour {
    public float speed;
    // Use this for initialization
    void Start () {
        int rotation = Random.Range(0, 3);
        if(rotation == 0)
        transform.rotation = Quaternion.Euler(311,233,295);
        if(rotation == 1)
        transform.rotation = Quaternion.Euler(311, 110, 423);
        if (rotation == 2)
        transform.rotation = Quaternion.Euler(295, 280, 266);
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * speed;
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
