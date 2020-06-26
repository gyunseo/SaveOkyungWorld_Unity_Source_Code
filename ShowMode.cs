using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMode : MonoBehaviour
{
    private Text Mode;
    // Start is called before the first frame update
    void Start()
    {
        Mode = gameObject.GetComponent<Text>();
        Mode.text = "Run away from ghosts and take the Pacdots!";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.FleeMode == true)
        {
            Mode.text = "Chase the ghosts! Quickly! Now!";
        }
        else
        {
            Mode.text = "Run away from ghosts and take the Pacdots!";
        }
    }
}
