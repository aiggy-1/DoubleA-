using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;


public class MC_Dialogue : MonoBehaviour
{
     [SerializeField] private TextAsset inkJSON;

   void Start()
    {
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }

}