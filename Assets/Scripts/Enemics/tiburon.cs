using UnityEngine;
using System.Collections;

public class tiburon : MonoBehaviour {

    public Vector3 objectiu;
    public float speed = 10;
    private Vector3 direccio;
    private bool activa = false;
    // Use this for initialization
    void Start()
    {
        Vector3 playerPosition = GameObject.Find("Player").GetComponent<Transform>().position;
        objectiu = playerPosition;
        direccio = new Vector3(objectiu.x - transform.position.x, objectiu.y - transform.position.y, objectiu.z - transform.position.z);
        direccio.Normalize();
        transform.LookAt(objectiu);
    }
    // Update is called once per frame
    void Update()
    {

            Vector3 moviment = new Vector3(Time.deltaTime * direccio.x, Time.deltaTime * direccio.y, Time.deltaTime * direccio.z);
            transform.position = transform.position + moviment * speed;


    }
}
