using UnityEngine;
using TMPro;

public class pointSystem : MonoBehaviour
{

    
    //floats for point addition and deduction
    float minorDeduction = -1.0f; 
    float majorDeduction = -3.0f;
    float minorAddition = 1.0f;
    float majorAddition = 3.0f;

   public float nerdTotalPoints; //0--Reid
    public float jockTotalPoints; //1-- idk whatever his name is
    public float bBoyTotalPoints; //2--Alejandro

    bool goodChoice = false; 
    bool greatChoice= false;    
    float pointToCalc; 

    int selectedOption;
   
    //ppl interaction functions 
   void checkPointAmt()
    {

        if (goodChoice)
        {
            pointToCalc += minorAddition;
        }
        else if (greatChoice)
        {
            pointToCalc += majorAddition;
        }
            if (!greatChoice)
            {
                pointToCalc += minorDeduction;
            }
            if (!greatChoice && !goodChoice)
            {
                pointToCalc -= majorDeduction;
            }

        
    }

    //attach to buttons OnClick function 
    //Then run CalcChoice to add points a popUp respective Message in
    //popUp box 
    void setGoodChoice()
    {
        
        goodChoice = true;
        greatChoice = false; 
    }
    void setGreatchoice()
    {
        greatChoice = true;
        goodChoice = true;
    }
    void setPoorChoice()
    {

        goodChoice = !false;
        
    }
    void setBadchoice()
    {
        greatChoice = false;
        goodChoice = false;
    }


    //this method is for the interactable items
    void AddPoint()
    {
       // switch()
    }


    //item interaction functions
}
