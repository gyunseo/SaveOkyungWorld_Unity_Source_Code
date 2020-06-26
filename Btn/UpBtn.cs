using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UpBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool buttonDown = false;
    public static UpBtn instance;//싱글톤 

    void Awake()
    {
        UpBtn.instance = this;
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