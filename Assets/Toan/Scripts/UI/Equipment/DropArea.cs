using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour
{
    public DragableItem currentItem;
    public List<DropCondition> DropConditions = new();
    public event Action<DragableItem> OnDropHandler;

    public bool Accepts(DragableItem dragable)
    {
        return DropConditions.TrueForAll(cond => cond.Check(dragable));
    }

    public void Drop(DragableItem dragable)
    {
        if (dragable.currentGrid && dragable.currentGrid.currentItem == dragable) dragable.currentGrid.currentItem = null;
        dragable.currentGrid = this;
        dragable.listParent = this.gameObject;
        dragable.transform.SetParent(this.transform);
        currentItem = dragable;
        OnDropHandler?.Invoke(dragable);
    }
}
