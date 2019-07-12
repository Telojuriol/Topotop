using UnityEngine;
using System.Collections;

public class scrollparallax3 : MonoBehaviour {
	public Texture[] myTextures = new Texture[23];
	public float speed = 20.0f;
    public GameObject control, fonsController;
    private bool inici = true;
    private Vector3 pujada;

    // Use this for initialization
    void Start () {
        GetComponent<Renderer>().material.mainTexture = myTextures[fonsController.GetComponent<fonsController>().iP3];
        pujada = new Vector3(0, 0, 45f);
        Vector3 movement = new Vector3(0, 0, -speed);
        GetComponent<Rigidbody>().velocity = movement;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inici)
        {
            GetComponent<Renderer>().material.mainTexture = myTextures[fonsController.GetComponent<fonsController>().iP1];
            inici = false;
        }
        Vector3 movement = new Vector3(0, 0, -speed);
        GetComponent<Rigidbody>().velocity = movement;
        if (this.transform.position.z <= -30f)
        {
            if (fonsController.GetComponent<fonsController>().iP3 % 2 == 1)
            {
                fonsController.GetComponent<fonsController>().iP3++;

            }

            if (fonsController.GetComponent<fonsController>().transP3)
            {

                fonsController.GetComponent<fonsController>().iP3++;
                fonsController.GetComponent<fonsController>().transP3 = false;
            }
            GetComponent<Renderer>().material.mainTexture = myTextures[fonsController.GetComponent<fonsController>().iP3];
            this.transform.position = new Vector3(0.0f, this.transform.position.y, this.transform.position.z + 45f);

        }
    }
}
