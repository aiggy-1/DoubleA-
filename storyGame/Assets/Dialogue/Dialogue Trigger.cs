using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject visualCue;

    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    public GameObject ObjectAttachedTo;

    private int interactions = 4;
    public int currentinteractions = 0;
    // 1st with computer
    //2-4th boys



    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
        ObjectAttachedTo.SetActive(true);
    }

    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                ObjectAttachedTo.SetActive(false);
                currentinteractions += 1;
            }
        }
        else
        {
            visualCue.SetActive(false);
        }

        if (currentinteractions == interactions)
           {
            ObjectAttachedTo.SetActive(true);
            }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
            Debug.Log("yeah..");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}