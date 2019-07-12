using UnityEngine;
using System.Collections;

public class enemic : MonoBehaviour {
    public int mal = 15;
    public int speed = 5;
    // Use this for initialization
    Vector3 movement = new Vector3(0.0f, 0.0f, 1);
    void Start () {
         
        GetComponent<Rigidbody>().velocity = movement * -speed;
    }
	
}
