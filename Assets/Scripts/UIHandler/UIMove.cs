using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class UIMove : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    public int m_Direction;
    //Do this when the mouse is clicked over the selectable object this script is attached to.
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was Clicked.");

        UIManager.Instance.m_Direction = m_Direction;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was UP.");
        UIManager.Instance.m_Direction = 0;
    }
}