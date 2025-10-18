using UnityEngine;
using TMPro;
using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
   [SerializeField] private GameObject[] choices;
    

    private Story currentStory;

    public bool dialogueIsPlaying { get; private set;}
    private TextMeshProUGUI[] choicesText;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More thna 1 af");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach(GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

    }
    
    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            ContinueStory();
        }
       /* if(Input.GetKeyDown(KeyCode.Space))
        {
            ExitDialogueMode();
        }*/
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {

        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if(currentChoices.Count > choices.Length)
        {
            Debug.Log("nah");
        }

        int index = 0;
        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; index++)
        {
            choices[i].gameObject.SetActive(false);
        }


    }
 }
