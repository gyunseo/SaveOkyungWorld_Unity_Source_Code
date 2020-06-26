using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangetoStartMenu()
    {
        SceneManager.LoadScene("Startmenu");
    }
    public void ReloadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
