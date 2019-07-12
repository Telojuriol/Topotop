using UnityEngine;
using System.Collections;

public class pedraTutorial : MonoBehaviour {

    public float speed;
    public float mal;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * speed;
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * 30;
      
    }
}
