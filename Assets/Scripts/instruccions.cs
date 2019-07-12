using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class instruccions : MonoBehaviour {

    public Sprite dreta;
    public Sprite centre;
    public Sprite esquerra;
    
    public float tempsCanvi;
    private float temps = 0;
	private int torn = 0;
    private int direccio = 1;
    void Start()
    {
        GetComponent<Image>().sprite = centre;

    }

	void Update () {
        temps += Time.deltaTime;
	    if(temps > tempsCanvi)
        {
            if(torn != 0)
                direccio = direccio * -1;
            torn += direccio;
            temps = 0;
        }
            


        if (torn == 0)
            GetComponent<Image>().sprite = centre;
        if (torn == 1)
            GetComponent<Image>().sprite = dreta;
        if (torn == -1)
            GetComponent<Image>().sprite = esquerra;




    }
}
