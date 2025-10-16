using UnityEngine;
using UnityEngine.SceneManagement; 

public class sceneSwapping : MonoBehaviour
{

    public GameObject pausePanel;
     bool panelActive;
    bool cursorActive = false; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            openEscapeMenu();   
        }
    }

   public void returnToMain()
    {
         
    }
   public void enterSchool()
    {

    }
    public void enterApartment()
    {

    }
        
    public void exitToCourtyard()
    {

    }
     void openEscapeMenu()
    {
        cursorActive = !cursorActive;
            panelActive = !panelActive;
        pausePanel.SetActive(panelActive);
        Cursor.visible=cursorActive;
        if (panelActive)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
}
