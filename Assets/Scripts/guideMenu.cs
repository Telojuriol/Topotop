using UnityEngine;
using System.Collections;

public class guideMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public void tornaMenu()
    {
        Application.LoadLevel("menus");

    }
    public void menuEnemics()
    {
        Application.LoadLevel("guiaEnemics");

    }
    public void menuNivells()
    {
        Application.LoadLevel("guiaFons");

    }

}
