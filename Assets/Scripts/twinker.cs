using UnityEngine;
using System.Collections;

public class twinker : MonoBehaviour {
    
    public float time = 0.2f;


    private float t = 0;
    private bool twink = false;


    void Update () {
        
        if (twink)
        {
            t += Time.deltaTime;
            if (t > time)
            {
                this.GetComponent<MeshRenderer>().enabled = !this.GetComponent<MeshRenderer>().enabled;
                t = 0;

            }
        }

	}

    public void startTwinkle()
    {
        twink = true;


    }


    public void stopTwinkle()
    {
        twink = false;
        this.GetComponent<MeshRenderer>().enabled = true;

    }


}
