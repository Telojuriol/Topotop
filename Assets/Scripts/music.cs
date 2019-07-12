using UnityEngine;
using System.Collections;

public class music : MonoBehaviour {

    private static music instance = null;
    private XMLPlayer xml;
    public static music Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        xml = new XMLPlayer();
        if (!xml.volume())
        {
            GameObject.Find("/Music").GetComponent<AudioSource>().volume = 0f;
        }
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }

}
