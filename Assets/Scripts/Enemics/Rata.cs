using UnityEngine;
using System.Collections;

public class Rata : MonoBehaviour {
    private Vector2 direccio;
    public float speed = 5;
    private float objectiu;
    // Use this for initialization
    void Start () {
        
        int punt = Random.Range(0,2);
        Vector3 position;
        if (punt == 0)
        { 
            int banda = (Random.Range(0, 2) * 2 - 1);
            float costat = Random.Range(2f, 7f);
            position = new Vector3(3.0f * banda, 0, costat);
        }
        else
        {
            position = new Vector3(Random.Range(-2f, 2f), 0, 7);
        }
        objectiu = Random.Range(-2f, 2f);
        direccio = new Vector2(objectiu - position.x , -5 - position.z );
        direccio.Normalize();
        transform.position = position;
        transform.LookAt(new Vector3(objectiu, 0, -5));
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 moviment = new Vector3(Time.deltaTime * direccio.x, 0, Time.deltaTime * direccio.y);
        transform.position = transform.position + moviment*speed;

    }
}
