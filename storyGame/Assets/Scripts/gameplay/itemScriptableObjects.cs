using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "itemScriptableObject",menuName= "ScriptableObject/itemData")]
public class itemScriptableObjects : ScriptableObject 
{
    public int selectedOption;
    public List<string> itemDialogue = new List<string>();
    public pointSystem ps;


    public void addPoint()
    {
        GameObject temp;
        temp = GameObject.Find("scriptManager");
        ps = temp.GetComponent<pointSystem>();
        switch (selectedOption)
        {


            case 0:
                ps.nerdTotalPoints += 2;
                break;
            case 1:
                ps.jockTotalPoints += 2;
                break;
            case 2:
                ps.bBoyTotalPoints += 2;
                break;
            default: break;

        }
    }

   public void totalPoints()
    {
        GameObject temp;
        temp = GameObject.Find("scriptManager");
        ps = temp.GetComponent<pointSystem>();

        Debug.Log("Total nerd points: " + ps.nerdTotalPoints + "Total jock points: " + ps.jockTotalPoints + "Total bBoy points: " + ps.bBoyTotalPoints);
    }

}
