using UnityEngine;
using TMPro;

public class pointSystem : MonoBehaviour
{

    //is game logic following like (current Task-- go to class, interact w/ something then task changes
    //then just like a couple of other things then school day ends? and then like idk she exits the school and
    //has a final dialog with who ever she had the most points with 
    //ends with them walk away or something? 

    
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
   float checkPointAmt()
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
return pointToCalc;
        
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


  //selected option parameter corresponds with who player is talking to
  //set selected option at the beginning of interaction 
    void AddToPerson(int selectedOption)
    {
        switch (selectedOption)
        {
            case 0:
                nerdTotalPoints += pointToCalc;
                break;
        case 1:
                jockTotalPoints += pointToCalc;
        break;
                case 2:
                bBoyTotalPoints += pointToCalc;
                break ;
        }
    }


   
}
