using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI NameText;
    [SerializeField] private Animator portraitAnimator;

    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManager instance;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string FATAL_ERROR = "error";

    public Behaviour stopMovement;

    //-----------------------

    public GameObject Nerd;
    public string nerdheartbreak = "NerdHeartBreak";
    public bool nhb = false;

    public GameObject Jock;
    public string jockheartbreak = "JockHeartBreak";
    public bool jhb = false;

    public GameObject BB;
    public string bbheartbreak = "BBHeartBreak";
    public bool bbhb = false;



    public int talkedto = 0;
    public int end = 3;
    public GameObject endpanel;
    public GameObject bNerd;
    public GameObject bBB;
    public GameObject bJock;
    public GameObject bFail;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        bFail.SetActive(false);
        bNerd.SetActive(false);
        bBB.SetActive(false);
        bJock.SetActive(false);

        endpanel.SetActive(false);
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        Debug.Log(talkedto);

        if (!dialogueIsPlaying)
        {
            return;
        }

        if (currentStory.currentChoices.Count == 0 && Input.GetKeyDown(KeyCode.E))
        {
            ContinueStory();
        }

        
    }

    

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        stopMovement.enabled = false;
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        NameText.text = "???";
        portraitAnimator.Play("default");

        ContinueStory();
    }




    private IEnumerator ExitDialogueMode()
    {
        stopMovement.enabled = true;

        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        talkedto += 1;

        if (talkedto == end)
        {
            stopMovement.enabled = false;
            endpanel.SetActive(true);


        if (nhb == false)
        {
            bNerd.SetActive(true);
        }

        if (jhb == false)
        {
            bJock.SetActive(true);
        }

        if (bbhb == false)
        {
            bBB.SetActive(true);
        }

        if (nhb == true && jhb == true && bbhb == true)
        {
            bFail.SetActive(true);
        }
      }
 

     }
        public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();

            DisplayChoices();

            HandleTags(currentStory.currentTags);
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }


    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] spiltTag = tag.Split(':');
            if (spiltTag.Length != 2)
            {
                Debug.Log("error");
            }
            string tagKey = spiltTag[0].Trim();
            string tagValue = spiltTag[1].Trim();

            switch(tagKey)
            {
                case SPEAKER_TAG:
                    NameText.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    break;
                case FATAL_ERROR:
                    if (tagValue == nerdheartbreak)
                    {
                        Destroy(Nerd);
                        nhb = true;
                    }
                    if (tagValue == jockheartbreak)
                    {
                        Destroy(Jock);
                        jhb = true;
                    }
                    if(tagValue == bbheartbreak)
                    {
                        Destroy(BB);
                        bbhb = true;
                    }
                    break;

                default:
                    Debug.Log("nope");
                    break;

            }
        }
    }

    

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("number choices or something");
        }

        int index = 0;

        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

}