using UnityEngine;
using System.Collections;

public class scroll : MonoBehaviour {
	public Texture[] myTextures = new Texture[23];
	public float speed = 20.0f;
    public float t;
    public GameObject control,fonsController;
	private int i;
    private bool inici = true;
    private Vector3 pujada;
    // Use this for initialization
    void Start () {
        GetComponent<Renderer>().material.mainTexture = myTextures[fonsController.GetComponent<fonsController>().iFons];
        pujada = new Vector3(0,0,45f);
        Vector3 movement = new Vector3(0,0, - speed);
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
        //        Debug.Log(control.GetComponent<GameController>().nivell);
        int nivell = control.GetComponent<GameController>().nivell;
        //this.transform.Translate(0, 0, 0.02f * speed * fonsController.GetComponent<fonsController>().velocitat);
        if(this.transform.position.z <= -30f)
        {

            if (fonsController.GetComponent<fonsController>().iFons % 2 == 1)
            {
                fonsController.GetComponent<fonsController>().iFons++;
                control.GetComponent<GameController>().nivell++;
                control.GetComponent<GameController>().nivellPujat = true;
                control.GetComponent<GameController>().tempsNivell = 0;
                fonsController.GetComponent<fonsController>().transFons = false;
                fonsController.GetComponent<fonsController>().transP2 = true;
                fonsController.GetComponent<fonsController>().transP3 = true;

            }

            if (fonsController.GetComponent<fonsController>().transFons && fonsController.GetComponent<fonsController>().iFons != 22)
            {
                
                fonsController.GetComponent<fonsController>().iFons++;
                fonsController.GetComponent<fonsController>().transP1 = true;
                fonsController.GetComponent<fonsController>().transFons = false;
            }
            GetComponent<Renderer>().material.mainTexture = myTextures[fonsController.GetComponent<fonsController>().iFons];
            transform.position = transform.position + pujada;
        }
    }
}
