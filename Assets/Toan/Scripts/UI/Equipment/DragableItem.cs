using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragableItem : MonoBehaviour, IInitializePotentialDragHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public event Action<PointerEventData> OnBeginDragHandler;
    public event Action<PointerEventData> OnDragHandler;
    public event Action<PointerEventData, bool> OnEndDragHandler;
    public bool FollowCursor { get; set; } = true;
    public Vector3 StartPosition;
    public bool CanDrag { get; set; } = true;
    public Canvas canvas;
    public GameObject listParent;
    public DropArea currentGrid;

    private void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        listParent = gameObject.transform.parent.gameObject;
        currentGrid = listParent.GetComponent<DropArea>();
        currentGrid.Drop(this);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!CanDrag)
        {
            return;
        }
        OnBeginDragHandler?.Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!CanDrag)
        {
            return;
        }
        OnDragHandler?.Invoke(eventData);
        if (FollowCursor)
        {
            gameObject.transform.SetParent(canvas.transform);
            gameObject.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!CanDrag)
        {
            return;
        }

        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        DropArea dropArea = null;

        foreach (var result in results)
        {
            Debug.Log(result.gameObject.name);
            dropArea = result.gameObject.GetComponent<DropArea>();

            if (dropArea)
            {
                break;
            }
        }

        if (dropArea)
        {
            if (dropArea.Accepts(this))
            {
                if(dropArea.currentItem)
                {
                    currentGrid.Drop(dropArea.currentItem);
                }
                dropArea.Drop(this);
                OnEndDragHandler?.Invoke(eventData, true);
                return;
            }
        }
        else
        {
            transform.SetParent(listParent.transform);
        }

        gameObject.GetComponent<RectTransform>().anchoredPosition = StartPosition;
        OnEndDragHandler?.Invoke(eventData, false);
    }

    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        StartPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
    }
}
