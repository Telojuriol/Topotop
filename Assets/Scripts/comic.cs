using UnityEngine;
using System.Collections;

public class comic : MonoBehaviour {
    private Vector3 vMoviment = new Vector3(-10,0,0);
    private int torn = 1;
    private XMLPlayer xml;
	void Start()
    {
        xml = new XMLPlayer();

    }
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + vMoviment*Time.deltaTime;
        if (transform.position.x <= 270 && torn == 1)
        {
            
            vMoviment.Set(-500, 0, 0);
            torn++;
        }
        if(torn == 2 && transform.position.x <=210)
        {
            vMoviment.Set(-10, 0, 0);
            torn++;

        }

        if (torn == 3 && transform.position.x <= 180)
        {
            vMoviment.Set(1000, 500, 0);
            torn++;

        }
        if (torn == 4 && transform.position.x >= 305)
        {
            vMoviment.Set(-10, 0, 0);
            torn++;

        }
        if (torn == 5 && transform.position.x <= 290)
        {
            vMoviment.Set(-1000, 0, 0);
            torn++;

        }
        if (torn == 6 && transform.position.x <= 210)
        {
            vMoviment.Set(-10, 0, 0);
            torn++;

        }
        if (torn == 7 && transform.position.x <= 180)
        {
            vMoviment.Set(1000, 550, 0);
            torn++;

        }
        if (torn == 8 && transform.position.x >= 305)
        {
            vMoviment.Set(-10, 0, 0);
            torn++;

        }
        if (torn == 9 && transform.position.x <= 290)
        {
            vMoviment.Set(-1000, 0, 0);
            torn++;

        }
        if (torn == 10 && transform.position.x <= 210)
        {
            vMoviment.Set(-10, 0, 0);
            torn++;

        }
        if (torn == 11 && transform.position.x <= 180)
        {
            vMoviment.Set(1000, 500, 0);
            torn++;

        }
        if (torn == 12 && transform.position.x >= 305)
        {
            vMoviment.Set(-10, 0, 0);
            torn++;

        }
        if (torn == 13 && transform.position.x <= 270)
        {
            vMoviment.Set(-1000, 0, 0);
            torn++;

        }
        if (torn == 14 && transform.position.x <= 210)
        {
            vMoviment.Set(-10, 0, 0);
            torn++;

        }
        if (torn == 15 && transform.position.x <= 150)
        {
            if(xml.firstPlay())
                Application.LoadLevel("Tutorial");
            else
                Application.LoadLevel("Ajustes");

        }
    }
    public void skipButton()
    {
        if (xml.firstPlay())
            Application.LoadLevel("Tutorial");
        else
            Application.LoadLevel("Ajustes");

    }
}
