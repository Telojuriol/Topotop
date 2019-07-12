using UnityEngine;
using System.Collections;

public class fonsController : MonoBehaviour {

    public bool transFons = false;
    public bool transP1 = false;
    public bool transP2 = false;
    public bool transP3 = false;
    public int iFons;
    public int iP1;
    public int iP2;
    public int iP3;
    public GameObject controller,player;
    public int nivell = 1;
    public int velocitat = 1;
    // Use this for initialization
    void Awake () {
        nivell = controller.GetComponent<GameController>().nivell;
        iFons = (nivell - 1) * 2;
        iP1 = (nivell - 1) * 2;
        iP2 = (nivell - 1) * 2;
        iP3 = (nivell - 1) * 2;
    }
	
}
