using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class adaptVida : MonoBehaviour {

    public Sprite[] imatgesBarresVida = new Sprite[5];
    public Sprite[] imatgesBarresFuel = new Sprite[5];


    private XMLPlayer xml;
    
    // Use this for initialization
    void Awake () {
        xml = new XMLPlayer();
        int vida = xml.getNivell("Vida");
        int fuel = xml.getNivell("Capacitat");
        switch (vida)
        {
            case 0:
                GameObject.Find("/Canvas/bordeVida").GetComponent<Image>().sprite = imatgesBarresVida[0];
                GameObject.Find("/Canvas/bordeVida").transform.localPosition = new Vector3(-215, 619, 0);
                GameObject.Find("/Canvas/bordeVida").GetComponent<RectTransform>().sizeDelta = new Vector2(270,92);

                GameObject.Find("/Canvas/Image").transform.localPosition = new Vector3(-171, 619, 0);
                GameObject.Find("/Canvas/Image").GetComponent<RectTransform>().sizeDelta = new Vector2(163, 60);

                GameObject.Find("/Canvas/backHealth").transform.localPosition = new Vector3(-171, 619, 0);
                GameObject.Find("/Canvas/backHealth").GetComponent<RectTransform>().sizeDelta = new Vector2(163, 60);
                break;

            case 1:
                GameObject.Find("/Canvas/bordeVida").GetComponent<Image>().sprite = imatgesBarresVida[1];
                GameObject.Find("/Canvas/bordeVida").transform.localPosition = new Vector3(-202, 619, 0);
                GameObject.Find("/Canvas/bordeVida").GetComponent<RectTransform>().sizeDelta = new Vector2(293, 92);

                GameObject.Find("/Canvas/Image").transform.localPosition = new Vector3(-160, 619, 0);
                GameObject.Find("/Canvas/Image").GetComponent<RectTransform>().sizeDelta = new Vector2(187, 60);

                GameObject.Find("/Canvas/backHealth").transform.localPosition = new Vector3(-160, 619, 0);
                GameObject.Find("/Canvas/backHealth").GetComponent<RectTransform>().sizeDelta = new Vector2(187, 60);

                break;


            case 2:
                GameObject.Find("/Canvas/bordeVida").GetComponent<Image>().sprite = imatgesBarresVida[2];
                GameObject.Find("/Canvas/bordeVida").transform.localPosition = new Vector3(-174, 619, 0);
                GameObject.Find("/Canvas/bordeVida").GetComponent<RectTransform>().sizeDelta = new Vector2(349, 92);

                GameObject.Find("/Canvas/Image").transform.localPosition = new Vector3(-131, 619, 0);
                GameObject.Find("/Canvas/Image").GetComponent<RectTransform>().sizeDelta = new Vector2(236, 60);

                GameObject.Find("/Canvas/backHealth").transform.localPosition = new Vector3(-131, 619, 0);
                GameObject.Find("/Canvas/backHealth").GetComponent<RectTransform>().sizeDelta = new Vector2(236, 60);


                break;

            case 3:
                GameObject.Find("/Canvas/bordeVida").GetComponent<Image>().sprite = imatgesBarresVida[3];
                GameObject.Find("/Canvas/bordeVida").transform.localPosition = new Vector3(-150, 619, 0);
                GameObject.Find("/Canvas/bordeVida").GetComponent<RectTransform>().sizeDelta = new Vector2(400, 92);

                GameObject.Find("/Canvas/Image").transform.localPosition = new Vector3(-104, 619, 0);
                GameObject.Find("/Canvas/Image").GetComponent<RectTransform>().sizeDelta = new Vector2(292, 60);

                GameObject.Find("/Canvas/backHealth").transform.localPosition = new Vector3(-104, 619, 0);
                GameObject.Find("/Canvas/backHealth").GetComponent<RectTransform>().sizeDelta = new Vector2(292, 60);

                break;

        }

        switch (fuel)
        {
            case 0:
                GameObject.Find("/Canvas/bordeFuel").GetComponent<Image>().sprite = imatgesBarresFuel[0];
                GameObject.Find("/Canvas/bordeFuel").transform.localPosition = new Vector3(-215, 522, 0);
                GameObject.Find("/Canvas/bordeFuel").GetComponent<RectTransform>().sizeDelta = new Vector2(270, 92);

                GameObject.Find("/Canvas/BarraFuel").transform.localPosition = new Vector3(-171, 522, 0);
                GameObject.Find("/Canvas/BarraFuel").GetComponent<RectTransform>().sizeDelta = new Vector2(163, 60);

                GameObject.Find("/Canvas/backFuel").transform.localPosition = new Vector3(-171, 522, 0);
                GameObject.Find("/Canvas/backFuel").GetComponent<RectTransform>().sizeDelta = new Vector2(163, 60);
                break;

            case 1:
                GameObject.Find("/Canvas/bordeFuel").GetComponent<Image>().sprite = imatgesBarresFuel[1];
                GameObject.Find("/Canvas/bordeFuel").transform.localPosition = new Vector3(-202, 522, 0);
                GameObject.Find("/Canvas/bordeFuel").GetComponent<RectTransform>().sizeDelta = new Vector2(293, 92);

                GameObject.Find("/Canvas/BarraFuel").transform.localPosition = new Vector3(-160, 522, 0);
                GameObject.Find("/Canvas/BarraFuel").GetComponent<RectTransform>().sizeDelta = new Vector2(187, 60);

                GameObject.Find("/Canvas/backFuel").transform.localPosition = new Vector3(-160, 522, 0);
                GameObject.Find("/Canvas/backFuel").GetComponent<RectTransform>().sizeDelta = new Vector2(187, 60);

                break;


            case 2:
                GameObject.Find("/Canvas/bordeFuel").GetComponent<Image>().sprite = imatgesBarresFuel[2];
                GameObject.Find("/Canvas/bordeFuel").transform.localPosition = new Vector3(-174, 522, 0);
                GameObject.Find("/Canvas/bordeFuel").GetComponent<RectTransform>().sizeDelta = new Vector2(349, 92);

                GameObject.Find("/Canvas/BarraFuel").transform.localPosition = new Vector3(-131, 522, 0);
                GameObject.Find("/Canvas/BarraFuel").GetComponent<RectTransform>().sizeDelta = new Vector2(236, 60);

                GameObject.Find("/Canvas/backFuel").transform.localPosition = new Vector3(-131, 522, 0);
                GameObject.Find("/Canvas/backFuel").GetComponent<RectTransform>().sizeDelta = new Vector2(236, 60);


                break;

            case 3:
                GameObject.Find("/Canvas/bordeFuel").GetComponent<Image>().sprite = imatgesBarresFuel[3];
                GameObject.Find("/Canvas/bordeFuel").transform.localPosition = new Vector3(-150, 522, 0);
                GameObject.Find("/Canvas/bordeFuel").GetComponent<RectTransform>().sizeDelta = new Vector2(400, 92);

                GameObject.Find("/Canvas/BarraFuel").transform.localPosition = new Vector3(-104, 522, 0);
                GameObject.Find("/Canvas/BarraFuel").GetComponent<RectTransform>().sizeDelta = new Vector2(292, 60);

                GameObject.Find("/Canvas/backFuel").transform.localPosition = new Vector3(-104, 522, 0);
                GameObject.Find("/Canvas/backFuel").GetComponent<RectTransform>().sizeDelta = new Vector2(292, 60);

                break;

        }






    }
	

}
