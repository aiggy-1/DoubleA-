using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject VisualCue;
    private bool InRange;




    private void Awake()
    {
        InRange = false;
        VisualCue.SetActive(false);
    }

    private void Update()
    {
        if (InRange)
        {
            VisualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.I))
            {
               
            }
        }
        else
        {
            VisualCue.SetActive(false);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            InRange = true;
}
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        { 
            InRange = false;
        }
    }


}