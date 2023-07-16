using UnityEngine;  
using UnityEngine.EventSystems;  
public class Joybutton: MonoBehaviour, IPointerUpHandler, IPointerDownHandler {  
    [HideInInspector]  
    public bool pressed;
    void Start() {}
    void Update() {}  
    
    public void OnPointerDown(PointerEventData eventData) {  
        pressed = true;  
    }  
    public void OnPointerUp(PointerEventData eventData) {  
        pressed = false;  
    }  
}   
