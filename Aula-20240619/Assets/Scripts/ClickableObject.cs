using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour, IPointerClickHandler
{
    public PointerEventData eventData;
    public void OnPointerClick(PointerEventData eventData)
    {
        this.eventData = eventData;
        Debug.Log(this);
    }
}
