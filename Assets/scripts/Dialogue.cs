using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("dialogue")]
public class Dialogue
{

    [XmlElement("node")]
    public Node[] Nodes;

    public static Dialogue Load(TextAsset xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Dialogue));
        StringReader reader = new StringReader(xml.text);
        Dialogue dial = serializer.Deserialize(reader) as Dialogue;
        return dial;
    }
}


[System.Serializable]
public class Node
{
    [XmlElement("npctext")]
    public string NpcText;

    [XmlArray("answers")]
    [XmlArrayItem("answer")]
    public Answer[] Answers;
}


[System.Serializable]
public class Answer
{
    [XmlAttribute("tonode")]
    public int NextNode;

    [XmlElement("text")]
    public string Text;

    [XmlElement("dialend")]
    public string End;

    [XmlAttribute("questvalue")]
    public int QuestValue;

    [XmlAttribute("needquestvalue")]
    public int NeedQuestValue;

    [XmlElement("questname")]
    public string QuestName;
}