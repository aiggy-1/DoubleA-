using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource background;
    public AudioSource eButton;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        background.Play();

    }

   

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            eButton.Play();
        }
    }
}
