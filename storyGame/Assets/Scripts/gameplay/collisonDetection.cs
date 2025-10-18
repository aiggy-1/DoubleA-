using UnityEngine;
using UnityEngine.UI;

public class collisonDetection : MonoBehaviour
{
    public interactable Interactable;
    public sceneSwapping sceneSwap;
    public Button bt; 
    bool canEnterSchool;
    bool PanelActive; 
    void Start()
    {
        //   sceneSwap= GetComponent<sceneSwapping>();
        
    }
    void Update()
    {
        if (canEnterSchool)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                sceneSwap.enterSchool();
            }
        }
        if (PanelActive && Input.GetKeyDown(KeyCode.Space))
        {
            Interactable.nextLine();
        }
    }
    
   void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("gate"))
        {
            Debug.Log("Touching Gate");
            canEnterSchool = true;
            
        }
        if (c.CompareTag("item"))
        {
            PanelActive = true;
            Interactable = c.gameObject.GetComponent<interactable>();
           // bt.onClick.AddListener(Interactable.nextLine);
            Debug.Log("Collision!");
            Interactable.activatePanel();
        }
    }
}
