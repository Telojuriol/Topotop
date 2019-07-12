using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class menuPrincipal: MonoBehaviour {

    private XMLPlayer xml;
    private Text monedas;
    public Sprite[] barresMillora = new Sprite[5];
    public Sprite[] imatgesPreus = new Sprite[5];
    private int nivellVelocitat;
    private int nivellValor;
    private int nivellVida;
    private int nivellValorFuel;
    private int nivellArrancada;
    private int nivellTurbo;
    private int nivellCapacitatFuel;
    private int nivellResistencia;
    private int nivellBotiquin;

    private GameObject guia;

    void Start()
    {
        carregaTot();
        

    }
    void carregaTot()
    {

        xml = new XMLPlayer();
        monedas = GameObject.Find("/Canvas/monedas").GetComponent<Text>();
        monedas.text = "" + xml.getMoney();
        nivellVelocitat = xml.getNivell("Velocitat");
        nivellVida = xml.getNivell("Vida");
        nivellValor = xml.getNivell("Valor");
        nivellValorFuel = xml.getNivell("ValorFuel");
        nivellArrancada = xml.getNivell("Arrancada");
        nivellTurbo = xml.getNivell("Turbo");
        nivellCapacitatFuel = xml.getNivell("Capacitat");
        nivellResistencia = xml.getNivell("Resistencia");
        nivellBotiquin = xml.getNivell("Botiquin");
        GameObject.Find("/Canvas/ScrollRect/Millores/velocitat/BarraMillora").GetComponent<Image>().sprite = barresMillora[nivellVelocitat];
        GameObject.Find("/Canvas/ScrollRect/Millores/vida/BarraMillora").GetComponent<Image>().sprite = barresMillora[nivellVida];
        GameObject.Find("/Canvas/ScrollRect/Millores/valor/BarraMillora").GetComponent<Image>().sprite = barresMillora[nivellValor];
        GameObject.Find("/Canvas/ScrollRect/Millores/valorFuel/BarraMillora").GetComponent<Image>().sprite = barresMillora[nivellValorFuel];
        GameObject.Find("/Canvas/ScrollRect/Millores/arrancada/BarraMillora").GetComponent<Image>().sprite = barresMillora[nivellArrancada];
        GameObject.Find("/Canvas/ScrollRect/Millores/turbo/BarraMillora").GetComponent<Image>().sprite = barresMillora[nivellTurbo];
        GameObject.Find("/Canvas/ScrollRect/Millores/capacitatFuel/BarraMillora").GetComponent<Image>().sprite = barresMillora[nivellCapacitatFuel];
        GameObject.Find("/Canvas/ScrollRect/Millores/resistencia/BarraMillora").GetComponent<Image>().sprite = barresMillora[nivellResistencia];
        GameObject.Find("/Canvas/ScrollRect/Millores/botiquin/BarraMillora").GetComponent<Image>().sprite = barresMillora[nivellBotiquin];

        GameObject.Find("/Canvas/ScrollRect/Millores/velocitat/Cost").GetComponent<Image>().sprite = imatgesPreus[nivellVelocitat];
        GameObject.Find("/Canvas/ScrollRect/Millores/vida/Cost").GetComponent<Image>().sprite = imatgesPreus[nivellVida];
        GameObject.Find("/Canvas/ScrollRect/Millores/valor/Cost").GetComponent<Image>().sprite = imatgesPreus[nivellValor];
        GameObject.Find("/Canvas/ScrollRect/Millores/valorFuel/Cost").GetComponent<Image>().sprite = imatgesPreus[nivellValorFuel];
        GameObject.Find("/Canvas/ScrollRect/Millores/arrancada/Cost").GetComponent<Image>().sprite = imatgesPreus[nivellArrancada];
        GameObject.Find("/Canvas/ScrollRect/Millores/turbo/Cost").GetComponent<Image>().sprite = imatgesPreus[nivellTurbo];
        GameObject.Find("/Canvas/ScrollRect/Millores/capacitatFuel/Cost").GetComponent<Image>().sprite = imatgesPreus[nivellCapacitatFuel];
        GameObject.Find("/Canvas/ScrollRect/Millores/resistencia/Cost").GetComponent<Image>().sprite = imatgesPreus[nivellResistencia];
        GameObject.Find("/Canvas/ScrollRect/Millores/botiquin/Cost").GetComponent<Image>().sprite = imatgesPreus[nivellBotiquin];

        guia = GameObject.Find("/Canvas/Instruccions");
        guia.SetActive(false);

    }
    public void loadLevel(){
		Application.LoadLevel ("toposcene");

	}

    public void closeIntructions()
    {
        guia.SetActive(false);

    }

    public void openIntructions()
    {
        guia.SetActive(true);

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

    public void milloraNivell()
    {
        //xml.milloraNivell(EventSystem.current.currentSelectedGameObject.name);
        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            case "velocitat":
                if(xml.getMoney() >= 800 * Mathf.Pow((nivellVelocitat + 1), 2) && nivellVelocitat < 4)
                {
                    nivellVelocitat++;
                    xml.setNivell("Velocitat", nivellVelocitat);
                    GameObject.Find("/Canvas/ScrollRect/Millores/" + EventSystem.current.currentSelectedGameObject.name + "/BarraMillora").GetComponent<Image>().sprite = barresMillora[nivellVelocitat];
                    GameObject.Find("/Canvas/ScrollRect/Millores/" + EventSystem.current.currentSelectedGameObject.name + "/Cost").GetComponent<Image>().sprite = imatgesPreus[nivellVelocitat];
                }
                
                break;

            case "vida":
                if (xml.getMoney() >= 800 * Mathf.Pow((nivellVida + 1), 2) && nivellVida < 4)
                {
                    nivellVida++;
                    xml.setNivell("Vida", nivellVida);
                    GameObject.Find("/Canvas/ScrollRect/Millores/" + EventSystem.current.currentSelectedGameObject.name + "/BarraMillora").GetComponent<Image>().sprite = barresMillora[nivellVida];
                    GameObject.Find("/Canvas/ScrollRect/Millores/" + EventSystem.current.currentSelectedGameObject.name + "/Cost").GetComponent<Image>().sprite = imatgesPreus[nivellVida];
                }
                break;

            case "valor":
                if (xml.getMoney() >= 800 * Mathf.Pow((nivellValor + 1), 2) && nivellValor < 4)
                {
                    nivellValor++;
                    xml.setNivell("Valor", nivellValor);
                    GameObject.Find("/Canvas/ScrollRect/Millores/" + EventSystem.current.currentSelectedGameObject.name + "/BarraMillora").GetComponent<Image>().sprite = barresMillora[nivellValor];
                    GameObject.Find("/Canvas/ScrollRect/Millores/" + EventSystem.current.currentSelectedGameObject.name + "/Cost").GetComponent<Image>().sprite = imatgesPreus[nivellValor];
                }
                break;
            case "valorFuel":
                if (xml.getMoney() >= 800 * Mathf.Pow((nivellValorFuel + 1), 2) && nivellValorFuel < 4)
                {
                    
                    nivellValorFuel++;
                    xml.setNivell("ValorFuel", nivellValorFuel);
                    GameObject.Find("/Canvas/ScrollRect/Millores/" + EventSystem.current.currentSelectedGameObject.name + "/BarraMillora").GetComponent<Image>().sprite = barresMillora[nivellValorFuel];
                    GameObject.Find("/Canvas/ScrollRect/Millores/" + EventSystem.current.currentSelectedGameObject.name + "/Cost").GetComponent<Image>().sprite = imatgesPreus[nivellValorFuel];
                }
                break;
            case "arrancada":
                if (xml.getMoney() >= 800 * Mathf.Pow((nivellArrancada + 1), 2) && nivellArrancada < 4)
                {
                    nivellArrancada++;
                    xml.setNivell("Arrancada", nivellArrancada);
                    GameObject.Find("/Canvas/ScrollRect/Millores/" + EventSystem.current.currentSelectedGameObject.name + "/BarraMillora").GetComponent<Image>().sprite = barresMillora[nivellArrancada];
                    GameObject.Find("/Canvas/ScrollRect/Millores/" + EventSystem.current.currentSelectedGameObject.name + "/Cost").GetComponent<Image>().sprite = imatgesPreus[nivellArrancada];
                }
                break;
            case "turbo":
                if (xml.getMoney() >= 800 * Mathf.Pow((nivellTurbo + 1), 2) && nivellTurbo < 4)
                {
                    nivellTurbo++;
                    xml.setNivell("Turbo", nivellTurbo);
                    GameObject.Find("/Canvas/ScrollRect/Millores/" + EventSystem.current.currentSelectedGameObject.name + "/BarraMillora").GetComponent<Image>().sprite = barresMillora[nivellTurbo];
                    GameObject.Find("/Canvas/ScrollRect/Millores/" + EventSystem.current.currentSelectedGameObject.name + "/Cost").GetComponent<Image>().sprite = imatgesPreus[nivellTurbo];
                }
                break;
            case "capacitatFuel":
                if (xml.getMoney() >= 800 * Mathf.Pow((nivellCapacitatFuel + 1), 2) && nivellCapacitatFuel < 4)
                {
                    nivellCapacitatFuel++;
                    xml.setNivell("Capacitat", nivellCapacitatFuel);
                    GameObject.Find("/Canvas/ScrollRect/Millores/" + EventSystem.current.currentSelectedGameObject.name + "/BarraMillora").GetComponent<Image>().sprite = barresMillora[nivellCapacitatFuel];
                    GameObject.Find("/Canvas/ScrollRect/Millores/" + EventSystem.current.currentSelectedGameObject.name + "/Cost").GetComponent<Image>().sprite = imatgesPreus[nivellCapacitatFuel];
                }
                break;
            case "resistencia":
                if (xml.getMoney() >= 800 * Mathf.Pow((nivellResistencia + 1), 2) && nivellResistencia < 4)
                {
                    nivellResistencia++;
                    xml.setNivell("Resistencia", nivellResistencia);
                    GameObject.Find("/Canvas/ScrollRect/Millores/" + EventSystem.current.currentSelectedGameObject.name + "/BarraMillora").GetComponent<Image>().sprite = barresMillora[nivellResistencia];
                    GameObject.Find("/Canvas/ScrollRect/Millores/" + EventSystem.current.currentSelectedGameObject.name + "/Cost").GetComponent<Image>().sprite = imatgesPreus[nivellResistencia];
                }
                break;

            case "botiquin":
                if (xml.getMoney() >= 800 * Mathf.Pow((nivellBotiquin + 1), 2) && nivellBotiquin < 4)
                {
                    nivellBotiquin++;
                    xml.setNivell("Botiquin", nivellBotiquin);
                    GameObject.Find("/Canvas/ScrollRect/Millores/" + EventSystem.current.currentSelectedGameObject.name + "/BarraMillora").GetComponent<Image>().sprite = barresMillora[nivellBotiquin];
                    GameObject.Find("/Canvas/ScrollRect/Millores/" + EventSystem.current.currentSelectedGameObject.name + "/Cost").GetComponent<Image>().sprite = imatgesPreus[nivellBotiquin];
                }
                break;
        }

        monedas = GameObject.Find("/Canvas/monedas").GetComponent<Text>();
        monedas.text = "" + xml.getMoney();





    }
	// Use this for initialization

}
