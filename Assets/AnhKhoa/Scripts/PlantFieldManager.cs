using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantFieldManager : MonoBehaviour
{
    public List<PlantField> plantFields = new List<PlantField>();

    void Start()
    {
        // Populate the plantFields list by finding all PlantField components among children
        FindAllPlantFields();
    }

    void FindAllPlantFields()
    {
        // Clear the existing list
        plantFields.Clear();

        // Find all child GameObjects with the PlantField component
        foreach (Transform child in transform)
        {
            PlantField plantField = child.GetComponent<PlantField>();
            if (plantField != null)
            {
                plantFields.Add(plantField);
            }
        }
    }
}
