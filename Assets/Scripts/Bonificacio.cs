using UnityEngine;
using System.Collections;

public class Bonificacio : MonoBehaviour {
    public int speed = 5;
    Vector3 movement = new Vector3(0.0f, 0.0f, 1);
    void Start()
    {
        
        GetComponent<Rigidbody>().velocity = movement * -speed;
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 3);
        //GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere;
    }

    void Update()
    {
        GetComponent<Rigidbody>().velocity = movement * -speed;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Femella")
        {
            Destroy(other.gameObject);
        }

    }

    // Update is called once per frame

}
