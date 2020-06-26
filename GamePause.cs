using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePause : MonoBehaviour
{
    public Text PauseText;
    public Text PausePoint;
    private void Awake()
    {
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Victory == true)
        {
            PauseText.text = "Victory!!";
            
            PausePoint.text = "Point: " + ((GameManager.PacDotCount - 3) * 10).ToString();
        }
        else if (GameManager.Defeat == true)
        {
            PauseText.text = "Defeat!!";

            PausePoint.text = "Point: " + ((GameManager.PacDotCount - 3) * 10).ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangetoStartMenu()
    {
        GameManager.instance.ResetGame();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Startmenu");
    }
    public void Retry()
    {
        
        GameManager.instance.ResetGame();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
        gameObject.SetActive(false);
       
    }
}
