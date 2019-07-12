using UnityEngine;
using System.Collections;

public class tutorialFons : MonoBehaviour {

    public float speed = 20.0f;
    private Vector3 pujada;

    void Start()
    {
        pujada = new Vector3(0, 0, 45f);
        Vector3 movement = new Vector3(0, 0, -speed);
        GetComponent<Rigidbody>().velocity = movement;
    }

    // Update is called once per frame
    void Update () {
        if (this.transform.position.z < -30f)
        {
            this.transform.position = this.transform.position + pujada;
        }
    }
}
