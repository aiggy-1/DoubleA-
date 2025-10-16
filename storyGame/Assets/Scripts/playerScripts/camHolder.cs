using UnityEngine;

public class camHolder : MonoBehaviour
{
    public Transform camPos; 

    // Update is called once per frame
    void Update()
    {
        transform.position = camPos.position;
    }
}
