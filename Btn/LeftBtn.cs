using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class LeftBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool buttonDown = false;
    public static LeftBtn instance;//싱글톤 

    void Awake()
    {
        LeftBtn.instance = this;
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