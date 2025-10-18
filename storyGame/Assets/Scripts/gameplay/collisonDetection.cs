using UnityEngine;
using UnityEngine.UI;

public class collisonDetection : MonoBehaviour
{
    public interactable Interactable;
    public sceneSwapping sceneSwap;
    public Button bt; 
    bool canEnterSchool;
    bool canEnterYard;
    bool canEnterHome;
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
        else if (canEnterYard)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                sceneSwap.exitToCourtyard();
            }
        }
        else if (canEnterHome)
        {
            sceneSwap.enterApartment();
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
        if (c.CompareTag("courtyard"))
        {
            Debug.Log("Touching Door");
            canEnterYard = true;    
        }
        if (c.CompareTag("home"))
        {
            canEnterHome = true;
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
