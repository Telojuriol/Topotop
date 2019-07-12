using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour {
    private GameObject infoPartida;
    public Sprite fuel;
    public Sprite vida;
    public AudioClip menu;
    // Use this for initialization
    void Awake () {
        infoPartida = GameObject.Find("InfoPartida");
        GameObject.Find("Music").GetComponent<AudioSource>().clip = menu;
        GameObject.Find("Music").GetComponent<AudioSource>().Play();
        GameObject.Find("/Canvas/Puntuacio").GetComponent<Text>().text = "" + infoPartida.GetComponent<InfoPartida>().puntuacio;
        if(infoPartida.GetComponent<InfoPartida>().motiuMort == 1)
        {
            GameObject.Find("/Canvas/motiuMort").GetComponent<Image>().sprite = vida;
        }
        else
        {
            GameObject.Find("/Canvas/motiuMort").GetComponent<Image>().sprite = fuel;

        }

        if (!infoPartida.GetComponent<InfoPartida>().logro) GameObject.Find("/Canvas/materialGuia").SetActive(false);

        if (!infoPartida.GetComponent<InfoPartida>().record) GameObject.Find("/Canvas/record").SetActive(false);




    }

    public void tornaMenu()
    {
        Destroy(infoPartida);
        Application.LoadLevel("menus");

    }
    public void playAgain()
    {
        Destroy(infoPartida);
        Application.LoadLevel("Loading");

    }

    public void goGuia()
    {
        Destroy(infoPartida);
        Application.LoadLevel("Guia");

    }

}
