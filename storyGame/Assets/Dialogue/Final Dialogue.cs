using UnityEngine;

public class FinalDialogue : MonoBehaviour
{
 [SerializeField] private TextAsset inkJSON;

    public void EnterEnd()
    {
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }

}