using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPacDotCount : MonoBehaviour
{
    private Text Point;
    // Start is called before the first frame update
    void Start()
    {
        Point = gameObject.GetComponent<Text>();
        Point.text = "Point: " + ((GameManager.PacDotCount-3)*10).ToString();//처음에 세개를 먹고 시작해서 카운트에서 -3을 해준다
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Point.text = "Point: " + ((GameManager.PacDotCount-3) * 10).ToString();
    }
}
