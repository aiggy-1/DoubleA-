using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;

    private Story currentStory;

    private bool dialogueIsPlaying;

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
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
    }
}