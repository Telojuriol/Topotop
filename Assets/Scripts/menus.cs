using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menus : MonoBehaviour {

    private XMLPlayer xml;
    void Awake()
    {
        xml = new XMLPlayer();
        if(xml.firstPlay()) Application.LoadLevel("comic");
    }

	public void loadLevel(){
		Application.LoadLevel ("Loading");

	}
	public void loadSettings(){
		Application.LoadLevel ("Ajustes");
		
	}
	public void loadUpgrades(){
		Application.LoadLevel ("Millores");
		
	}
	public void loadMissions(){
		Application.LoadLevel ("Missions");
		
	}
	public void loadQuit(){
		Application.Quit ();
		
	}
	public void tornaMenu(){
		Application.LoadLevel ("menus");
		
	}
    public void loadGuia()
    {
        Application.LoadLevel("Guia");

    }

    // Use this for initialization

}
