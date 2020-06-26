using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class RightBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool buttonDown = false;
    public static RightBtn instance;//싱글톤 
    
    void Awake() {
        RightBtn.instance = this;
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