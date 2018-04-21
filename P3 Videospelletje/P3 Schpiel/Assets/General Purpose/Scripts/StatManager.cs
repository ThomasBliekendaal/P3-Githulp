using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using System.IO;
using System.Xml.Serialization;

public class StatManager : MonoBehaviour {
    public gotPendants gotPendantos;
    [System.Serializable]
    public class gotPendants
    {
        public bool[] gotPendant;
    }
	// Use this for initialization
	void Start ()
    {

	}

	// Update is called once per frame
	void Update () {
		
	}
    public void AddPendant(int pendantIndex)
    {
        gotPendantos.gotPendant[pendantIndex] = true;
    }
    public void OnApplicationQuit()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(gotPendants));
        FileStream stream = new FileStream(Application.dataPath + "/General Purpose/Scripts/SaveData/saveData.xml", FileMode.Create);
        serializer.Serialize(stream, gotPendantos);
        stream.Close();
    }
    public void Awake()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(gotPendants));
        FileStream stream = new FileStream(Application.dataPath + "/General Purpose/Scripts/SaveData/saveData.xml", FileMode.Open);
        gotPendantos = (gotPendants)serializer.Deserialize(stream);
        stream.Close();
    }
}
