using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Millora{


    [XmlAttribute("name")]
    public string name;

    [XmlElement("Descripcio")]
    public string descripcio;

    [XmlElement("Nivell")]
    public float damage;


}
