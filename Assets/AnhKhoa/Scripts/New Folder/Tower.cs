using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : InventoryItemBase
{
    public string towerName;
    public GameObject tower;
    private Transform place;

    public void Start()
    {
        PlayerAction.sowInput += PLaceItem;
    }
    public void PLaceItem()
    {

        if (!FindObjectOfType<PlayerPlantTower>().currentHighlightedPlantField.occupied && isUsing)
        {
            place = FindObjectOfType<PlayerPlantTower>().currentHighlightedPlantField.transform;
            GameObject newPlant = Instantiate(tower, place.position, Quaternion.identity);
            newPlant.GetComponent<Tower>().enabled = false;
            FindObjectOfType<PlayerPlantTower>().currentHighlightedPlantField.occupied = true;
        }

    }
}