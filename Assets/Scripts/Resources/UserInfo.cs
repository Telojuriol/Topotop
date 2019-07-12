using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

[XmlRoot("Userinfo")]
public class UserInfo {

    [XmlElement("Tutorial")]
    public int tutorial;

    [XmlElement("Volum")]
    public int volum;

    [XmlElement("Money")]
    public int money;

    [XmlElement("Record")]
    public int record;

    [XmlArray("Millores")]
    [XmlArrayItem("Millora")]
    public List<Millora> items = new List<Millora>();


    [XmlArray("Logros")]
    [XmlArrayItem("Logro")]
    public List<Logro> logros = new List<Logro>();

    public static UserInfo Load()
    {
        XmlDocument _xml = new XmlDocument();
        _xml.Load(Application.persistentDataPath + "/items.xml");
        string text;
        StringWriter sw = new StringWriter();
        XmlTextWriter tx = new XmlTextWriter(sw);
        _xml.WriteTo(tx);
        text = sw.ToString();
        XmlSerializer serializer = new XmlSerializer(typeof(UserInfo));

        StringReader reader = new StringReader(text);

        UserInfo items = serializer.Deserialize(reader) as UserInfo;

        reader.Close();
        return items;
    }

    public static UserInfo Inicial()
    {
        
        TextAsset _xml = Resources.Load<TextAsset>("items");

        XmlSerializer serializer = new XmlSerializer(typeof(UserInfo));
        
        StringReader reader = new StringReader(_xml.text);

        UserInfo items = serializer.Deserialize(reader) as UserInfo;

        reader.Close();
        return items;
    }
    public void Save(string path)
    {

        XmlSerializer serializer = new XmlSerializer(typeof(UserInfo));
        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
       
    }

   

    }
