using UnityEngine;
using System.Collections;

public class Estel : MonoBehaviour {

    private float timeCounter = 0;
    public float speed = 1;
    public float width = 5;
    public float height = 1;
    // Use this for initialization
    void Start()
    {
        timeCounter = Random.Range(-3f,3f);
        GetComponent<Transform>().position = new Vector3(-1.9f * Mathf.Cos(timeCounter), 0, 20);
        //GetComponent<Transform>().position = new Vector3(0, 0, 20);

    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime * speed;
        float x = (Mathf.Cos(timeCounter - Time.deltaTime*speed) - Mathf.Cos(timeCounter)) * width;
        transform.position = new Vector3(transform.position.x + x, transform.position.y, transform.position.z);
       
    }
}
