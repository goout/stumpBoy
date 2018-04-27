using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateDialogue : MonoBehaviour
{


    [SerializeField] private TextAsset textAsset;
	[SerializeField] private GUISkin skin;
	[SerializeField] private  List<Answer> answers = new List<Answer>();

    private Dialogue dialogue;
    private int currentNode;
    private bool ShowDialogue;
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        dialogue = Dialogue.Load(textAsset);
        audioSource = GetComponent<AudioSource>();
        Debug.Log(dialogue.Nodes[0].Answers[0].Text);
        Debug.Log(dialogue.Nodes[0].NpcText);
    }

    // Update is called once per frame
    void Update()
    {

        answers.Clear();
        for (int i = 0; i < dialogue.Nodes[currentNode].Answers.Length; i++)
        {
            if (dialogue.Nodes[currentNode].Answers[i].QuestName == null
            || dialogue.Nodes[currentNode].Answers[i].NeedQuestValue == PlayerPrefs.GetInt(dialogue.Nodes[currentNode].Answers[i].QuestName))
                answers.Add(dialogue.Nodes[currentNode].Answers[i]);
        }

    }


    void OnMouseDown()
    {
        Debug.Log("show dialog");
        BoyCntrl.InDialogue = true;
        ShowDialogue = true;
    }



    void OnGUI()
    {
        GUI.skin = skin;
        if (ShowDialogue)
        {

            GUI.Box(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 295, 800, 200), "");
            GUI.Label(new Rect(Screen.width / 2 - 350, Screen.height / 2 - 250, 700, 150), dialogue.Nodes[currentNode].NpcText);

            for (int i = 0; i < answers.Count; i++)
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 350, Screen.height / 2 - 80 + 110 * i, 700, 100), answers[i].Text, skin.button))
                {
                    if (answers[i].QuestValue > 0)
                    {
                        PlayerPrefs.SetInt(answers[i].QuestName, answers[i].QuestValue);
                        audioSource.Play();
                        Debug.Log("GET QUEST");
                    }
                    if (answers[i].End == "true")
                    {
                        ShowDialogue = false;
                        BoyCntrl.InDialogue = false;
                    }
                    currentNode = answers[i].NextNode;
                }
            }

        }
    }

}
