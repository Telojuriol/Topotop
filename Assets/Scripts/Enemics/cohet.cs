using UnityEngine;
using System.Collections;

public class cohet : MonoBehaviour {

    private float timeCounter = 0;
    private float speed;
    private float width;
    private float height;
    // Use this for initialization
    void Start()
    {
        width = 1;
        speed = 2;
        GetComponent<Transform>().position = new Vector3(Random.Range(-2f, 2f), 0, 20);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime * speed;
        float x = (Mathf.Cos(timeCounter - Time.deltaTime) - Mathf.Cos(timeCounter)) * width;
        
        Vector3 movement = new Vector3(x,0,0);
        GetComponent<Transform>().position = transform.position + movement;
        
    }
}
