using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pause : MonoBehaviour {
    public bool paused = false;
    private GameObject menuPausa;
    private XMLPlayer xml;
    public Sprite on, off;
    private int timescale;
    private GameObject controller;
    private GameObject audios;
    public AudioClip menu;
    // Use this for initialization
    void Start () {
        controller = GameObject.Find("/Jugador/Player");
        audios = GameObject.Find("/Audios");
        xml = new XMLPlayer();
        menuPausa = GameObject.Find("/Canvas/menuPausa");
        
        if (xml.volume())
        {
            GameObject.Find("/Canvas/menuPausa/Mute").GetComponent<Image>().sprite = on;
            audios.SetActive(true);
        }
        else {
            GameObject.Find("/Canvas/menuPausa/Mute").GetComponent<Image>().sprite = off;
            audios.SetActive(false);
        }

        menuPausa.SetActive(false);
    }
	

    public void pauseGame()
    {
        timescale = controller.GetComponent<playerController>().scale;
        Time.timeScale = 0;
        paused = true;
        menuPausa.SetActive(true);

    }

    public void resumeGame()
    {
        menuPausa.SetActive(false);
        Time.timeScale = timescale;
        paused = false;
    }

    public void tornaMenu()
    {
        Time.timeScale = 1;
        GameObject.Find("Music").GetComponent<AudioSource>().clip = menu;
        GameObject.Find("Music").GetComponent<AudioSource>().Play();
        Application.LoadLevel("menus");

    }

    public void muteGame()
    {
        xml.muteGame();
        if (xml.volume())
        {
            GameObject.Find("/Music").GetComponent<AudioSource>().volume = 0.55f;
            GameObject.Find("/Canvas/menuPausa/Mute").GetComponent<Image>().sprite = on;
            audios.SetActive(true);
        }
        else {
            GameObject.Find("/Music").GetComponent<AudioSource>().volume = 0;
            GameObject.Find("/Canvas/menuPausa/Mute").GetComponent<Image>().sprite = off;
            audios.SetActive(false);
        }


    }


}
