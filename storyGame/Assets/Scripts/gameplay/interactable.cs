using UnityEngine;
using TMPro; 
public class interactable : MonoBehaviour
{
    public itemScriptableObjects item;
    public pointSystem ps;
    public GameObject popUpBox;
    public TMP_Text popUpText;
    int num = 0;

    GameObject temp; 
   
    void Start()
    {
        temp= GameObject.Find("scriptManager");
        ps=temp.GetComponent<pointSystem>();
    }
   public void setText()
    {
        popUpText.text = item.itemDialogue[num];
    }
   public void nextLine()
    {
        num++;
        if (num == item.itemDialogue.Count)
        {

            popUpBox.SetActive(false);
            gameObject.SetActive(false);
            num = 0;
        }
        popUpText.text = item.itemDialogue[num];
       
    }

   public void activatePanel()
    {
        Cursor.visible = true;
        popUpBox.SetActive(true);
        setText();
        item.addPoint();
        item.totalPoints();
    }

   

}
