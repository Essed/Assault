using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;




public class MobileController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    private Image JoystickBG; // задник джойстика
    private Image Joystick; // джойстик
    private Vector2 inputVector; // получение координаты джойстика 


    private void Start()
    {
        JoystickBG = GetComponent<Image>();
        Joystick = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;

        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(JoystickBG.rectTransform,eventData.position,eventData.pressEventCamera,out pos))
        {
            pos.x = (pos.x / JoystickBG.rectTransform.sizeDelta.x); // получение координат позиции касания на джойстик 
            pos.y = (pos.y / JoystickBG.rectTransform.sizeDelta.y); // получение координат позиции касания на джойстик

            inputVector = new Vector2(pos.x * 2, pos.y * 2); // установка точных координат из касания
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
            Joystick.rectTransform.anchoredPosition = new Vector2(inputVector.x * (JoystickBG.rectTransform.sizeDelta.x / 2), inputVector.y * (JoystickBG.rectTransform.sizeDelta.y / 2));
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        Joystick.rectTransform.anchoredPosition = Vector2.zero;  // возврат джойстика в центр
    }

    public float Horizontal()
    {
        if (inputVector.x != 0) return inputVector.x; // перехват оси при отсутствии изменений
        else return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (inputVector.y != 0) return inputVector.y; // перехват оси при отсутствии изменений
        else return Input.GetAxis("Vertical");
    }

}
