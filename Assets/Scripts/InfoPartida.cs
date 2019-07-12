using UnityEngine;
using System.Collections;

public class InfoPartida : MonoBehaviour
{

    private static InfoPartida instance = null;
    public bool record = false;
    public bool logro = false;
    public int puntuacio = 0;
    public int motiuMort = 0;
    public static InfoPartida Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }

}
