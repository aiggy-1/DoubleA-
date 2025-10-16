using UnityEngine;

public class collisonDetection : MonoBehaviour
{
    public sceneSwapping sceneSwap;

    void Start()
    {
     //   sceneSwap= GetComponent<sceneSwapping>();
    }
    
   void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("gate"))
        {
            if (Input.GetKeyDown(KeyCode.E)) { 
            sceneSwap.enterSchool();
        }
        }
    }
}
