using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler
{   
    public void OnDrag(PointerEventData eventData) {
        Vector3 mousepos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

        transform.position = mousepos;
    }
}
