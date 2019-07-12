using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ajustes : MonoBehaviour {
    private XMLPlayer xml;
    public Sprite on, off;
	// Use this for initialization
	void Start () {
        xml = new XMLPlayer();
        if (xml.volume())
        {
            GameObject.Find("/Canvas/Mute").GetComponent<Image>().sprite = on;
        }else{
            GameObject.Find("/Canvas/Mute").GetComponent<Image>().sprite = off;
        }
    }
	public void resetUpgrades()
    {
        xml.setNivell("Velocitat", 0);
        xml.setNivell("Vida", 0);
        xml.setNivell("Valor", 0);
        xml.setNivell("ValorFuel", 0);
        xml.setNivell("Arrancada", 0);
        xml.setNivell("Turbo", 0);
        xml.setNivell("Capacitat", 0);
        xml.setNivell("Resistencia", 0);
        xml.setNivell("Botiquin", 0);
    }


    public void resetAchievements()
    {
        xml.resetLogros();
    }

    public void tornaMenu()
    {
        Application.LoadLevel("menus");

    }

    public void tutorial()
    {
        Application.LoadLevel("Tutorial");

    }

    public void comic()
    {
        Application.LoadLevel("comic");

    }

    public void muteGame()
    {
        xml.muteGame();
        if (xml.volume())
        {
            GameObject.Find("/Music").GetComponent<AudioSource>().volume = 0.55f;
            GameObject.Find("/Canvas/Mute").GetComponent<Image>().sprite = on;
        }
        else
        {
            GameObject.Find("/Music").GetComponent<AudioSource>().volume = 0;
            GameObject.Find("/Canvas/Mute").GetComponent<Image>().sprite = off;
        }
    }


}
