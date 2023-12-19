using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : InventoryItemBase
{
    public GameObject tower;
    private Transform place;

    public void Start()
    {
        PlayerAction.sowInput += PLaceItem;
    }
    public void PLaceItem()
    {
        
        place = FindObjectOfType<PlayerPlantTower>().currentHighlightedPlantField.transform;
        Instantiate(tower, place.position, Quaternion.identity);
    }
}