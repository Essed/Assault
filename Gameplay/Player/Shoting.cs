using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class Shoting : MonoBehaviour,IPointerUpHandler,IPointerDownHandler {

      
    [HideInInspector]
    public bool shot;
    [HideInInspector]
    public byte detectShot = 0;
       
    public void OnPointerUp(PointerEventData eventData) // перестал стрелять
    {
        shot = false;     
    }
    public void OnPointerDown(PointerEventData eventData) // начал стрелять
    {
        shot = true;
    }    

}
