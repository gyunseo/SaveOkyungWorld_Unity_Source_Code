using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DownBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool buttonDown = false;
    public static DownBtn instance;//싱글톤 

    void Awake()
    {
        DownBtn.instance = this;
    }
    void Start()
    {

    }

    void FixedUpdate()
    {

    }

    public void OnPointerDown(PointerEventData ped)
    {
        buttonDown = true;
    }
    public void OnPointerUp(PointerEventData ped)
    {
        buttonDown = false;
    }
}