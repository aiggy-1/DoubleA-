using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;


public class MC_Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI textComputer;

    public GameObject textborder;
    public GameObject compBorder;
   


    public string[] lines1; //Start game
    public string[] lines2; //Computer
    public string[] lines3; // after objects collected 
    public string[] lines4; // Final Computer


    public float textSpeed; 

    private int index; 


    public bool Morning = true;
    public int InteractionsWComputer = 0;
    public int ObjectsCollected = 0;
    private int ObjectsNeeded = 3;
    public bool complete3 = false;
    public bool talkedto = false;


    void Start()
    {
        textborder.SetActive(false);
        compBorder.SetActive(false);

        textComponent.text = string.Empty;
        textComputer.text = string.Empty;

        if (Morning == true)
        {
            textborder.SetActive(true);
            StartDialogue();
        }
        
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Morning == true)
            {
                if (textComponent.text == lines1[index])
                {
                    Nextline();
                }

                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines1[index];
                }
            }


            if (InteractionsWComputer == 1)
            {
                if (textComputer.text == lines2[index])
                {
                    Nextline();
                }

                else
                {
                    StopAllCoroutines();
                    textComputer.text = lines2[index];
                }
            }

            if (ObjectsCollected == ObjectsNeeded)
            {
                textborder.SetActive(true);
                StartDialogue();
                ObjectsNeeded = 0;
                complete3 = true;
            }

            if (complete3 == true)
            {
                if (textComponent.text == lines3[index])
                {
                    Nextline();
                }

                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines3[index];
                }
            }


        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            ComputerClicked();
            Morning = false;
        }

       
    }



    void StartDialogue() //used for all 
    {
        index = 0;
        StartCoroutine(TypeLine());
    }


    IEnumerator TypeLine()
    {
       if (Morning == true)
       {
            foreach (char c in lines1[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }


        if (InteractionsWComputer == 1)
        {
            foreach (char c in lines2[index].ToCharArray())
            {
                textComputer.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }
       

        if (complete3 == true)
        {
             foreach (char c in lines3[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }


    }




    void Nextline()
    {
      if (Morning == true)
       {
        if (index < lines1.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            
         }
         else
         {
           textborder.SetActive(false);
           textComponent.text = string.Empty;
           
            }
        }



      if (InteractionsWComputer == 1)
         {
          if (index < lines2.Length - 1)
          {
             index++;
                textComputer.text = string.Empty;
             StartCoroutine(TypeLine());
             
            }
           else
           {
              compBorder.SetActive(false);
                textComputer.text = string.Empty;
            }
        }


        if (complete3 == true)
        {
            if (index < lines3.Length - 1)
            {
                index++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());

            }
            else
            {
                textborder.SetActive(false);
                textComponent.text = string.Empty;

            }
        }

    }


    public void ComputerClicked() //THIS WONT WORK. MAKE AN INSTANCE OF A TRIGGER IN DIALOGUE TRIIGER. THAN CHEKC FOR COLLISION AND INTERACTION. FUCK MY LFIE

    {
        if(InteractionsWComputer == 0)
        {
            StartDialogue();
            InteractionsWComputer += 1;
            compBorder.SetActive(true);
        }
    }
}

