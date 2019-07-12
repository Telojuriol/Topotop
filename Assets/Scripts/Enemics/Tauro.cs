using UnityEngine;
using System.Collections;

public class Tauro : MonoBehaviour {
    private float timeCounter = 0;
    private float speed;
    private float width;
    private float height;
    // Use this for initialization
    void Start () {
        width = 2;
        speed = 3;
        GetComponent<Transform>().position = new Vector3(Random.Range(-1.9f, 1.9f), 0, 20);
    }
	
	// Update is called once per frame
	void Update () {
        timeCounter += Time.deltaTime * speed;
        float x = (Mathf.Cos(timeCounter - Time.deltaTime) - Mathf.Cos(timeCounter ) ) * width;
        GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + x, GetComponent<Transform>().position.y,GetComponent<Transform>().position.z);
        GetComponent<Transform>().rotation = Quaternion.Euler(GetComponent<Transform>().rotation.eulerAngles.x, GetComponent<Transform>().rotation.eulerAngles.y , GetComponent<Transform>().rotation.eulerAngles.z );
    }
}
