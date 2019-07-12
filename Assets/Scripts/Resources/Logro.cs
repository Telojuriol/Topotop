using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Logro {

    [XmlAttribute("name")]
    public string name;

    [XmlElement("Aconseguit")]
    public float damage;
}
