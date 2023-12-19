using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlantTower : MonoBehaviour
{
    public float raycastDistance = 5f;
    public Color highlightColor = new Color(0.7f, 0.7f, 0.7f, 0.5f); // Adjust the highlight color and transparency

    private MeshRenderer lastHighlightedMeshRenderer;
    private Camera playerCamera;
    public PlantField currentHighlightedPlantField;

    private CameraSwitcher cameraSwitcher; // Reference to the CameraSwitcher

    void Start()
    {
        cameraSwitcher = FindObjectOfType<CameraSwitcher>(); // Find the CameraSwitcher in the scene
    }

    void Update()
    {
        playerCamera = GetComponentInChildren<Camera>();
        CheckPlantField();

    }

    void CheckPlantField()
    {
        Ray ray;

        // Check if the first-person camera is active
        if (cameraSwitcher != null && cameraSwitcher.isFirstPersonActive)
        {
            // Use the first-person camera for raycasting
            ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        }
        else
        {
            // Use the third-person camera for raycasting
            ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        }

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            MeshRenderer meshRenderer = hit.collider.GetComponent<MeshRenderer>();

            // Check if the object hit is considered as plant field
            if (meshRenderer != null && hit.collider.CompareTag("PlantField"))
            {
                
                
                // Highlight the plant field by changing its material transparency
                HighlightPlantField(meshRenderer);

                // Store the currently highlighted plant field
                currentHighlightedPlantField = hit.collider.GetComponent<PlantField>();
            }
        }
        else
        {
            // If the ray doesn't hit anything, remove the highlight from the previous hit object
            RemoveHighlight();

            // Clear the current highlighted plant field
            currentHighlightedPlantField = null;
        }

        // Draw the ray in the Scene view (for debugging purposes)
        Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.green);
    }

    void HighlightPlantField(MeshRenderer meshRenderer)
    {
        GetHighlightedPlantFieldPosition();
        // Check if the plant field has a MeshRenderer component
        if (meshRenderer != null)
        {
            // Remove the highlight from the previous mesh renderer
            RemoveHighlight();

            // Change the material color to create the highlight effect
            meshRenderer.material.color = highlightColor;

            // Store the currently highlighted mesh renderer
            lastHighlightedMeshRenderer = meshRenderer;
        }
    }

    void RemoveHighlight()
    {
        // Remove the highlight effect from the previous plant field
        if (lastHighlightedMeshRenderer != null)
        {
            // Reset the material color to the default color
            lastHighlightedMeshRenderer.material.color = Color.white;

            // Clear the stored reference
            lastHighlightedMeshRenderer = null;
        }
    }

    // Function to access the position of the currently highlighted plant field
   public void GetHighlightedPlantFieldPosition()
    {
        if (currentHighlightedPlantField != null)
        {
            Vector3 plantFieldPosition = currentHighlightedPlantField.transform.position;
        }
    }
}
