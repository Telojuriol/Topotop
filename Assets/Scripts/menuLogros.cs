using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class menuLogros : MonoBehaviour {
    private XMLPlayer xml;
    public Sprite[] medallas = new Sprite[12];
    // Use this for initialization
    void Start () {
        xml = new XMLPlayer();
        GameObject.Find("/Canvas/Record").GetComponent<Text>().text = "" + xml.getRecord() + " m.";
        for (int i = 0; i < xml.getNumLogros(); i++)
        {
            if (xml.getLogro(i + 1))
            {
                string path = "/Canvas/Logros/Nivell" + (i + 1);
                GameObject.Find(path).SetActive(true);

            }

        }
	}
	

    public void tornaMenu()
    {
        Application.LoadLevel("menus");

    }
}
