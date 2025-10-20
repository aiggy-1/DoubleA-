using UnityEngine;
using UnityEngine.SceneManagement; 

public class sceneSwapping : MonoBehaviour
{
    public GameObject Managers;
    public GameObject UI;
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
        SceneManager.LoadScene("mainMenu");

    }
    public void enterSchool()
    {
        SceneManager.LoadScene("school");
        DontDestroyOnLoad(Managers);
        DontDestroyOnLoad(UI);
    }
    public void enterApartment()
    {
        SceneManager.LoadScene("apartment");
        DontDestroyOnLoad(Managers);
        DontDestroyOnLoad(UI);
    }

    public void exitToCourtyard()
    {
        SceneManager.LoadScene("SampleScene");
        DontDestroyOnLoad(Managers);
        DontDestroyOnLoad(UI);

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
