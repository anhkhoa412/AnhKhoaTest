using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    protected DropArea DropArea;
    public int id;

    protected virtual void Awake()
    {
        DropArea = GetComponent<DropArea>() ?? gameObject.AddComponent<DropArea>();
        DropArea.OnDropHandler += OnItemDropped;
    }

    private void OnItemDropped(DragableItem dragable)
    {
        dragable.transform.position = transform.position;
    }
}
