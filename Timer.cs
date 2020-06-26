using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public static float time;
    private Text TimeText;
    // Start is called before the first frame update
    void Start()
    {
        TimeText = gameObject.GetComponent<Text>();
        time = 80f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (time != 0f)
        {
            time -= Time.deltaTime;
            if(time<=0f)
            {
                time = 0f;
            }
        }
        int _time_ = Mathf.FloorToInt(time);
        TimeText.text = "Time: " + _time_.ToString();
    }
}
