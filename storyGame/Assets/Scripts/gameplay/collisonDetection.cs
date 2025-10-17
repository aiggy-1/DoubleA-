using UnityEngine;

public class collisonDetection : MonoBehaviour
{
    public sceneSwapping sceneSwap;
    bool canEnterSchool;
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
    }
    
   void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("gate"))
        {
            Debug.Log("Touching Gate");
            canEnterSchool = true;
            
        }
    }
}
