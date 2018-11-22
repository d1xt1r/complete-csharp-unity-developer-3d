using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]

public class CubeEditor : MonoBehaviour {

    Waypoint waypoint;

    private void Awake() // Awake is called even before Start
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid() // snapping the cubes to grid
    {
        int gridSize = waypoint.GetGridSize(); // get the gridsize from waypoint script
        transform.position = new Vector3(
            waypoint.GetGridPos().x * gridSize, // get the grid position from waypoint script
            0f,
            waypoint.GetGridPos().y * gridSize // get the grid position from waypoint script
        );
    }

    private void UpdateLabel() // labeling the cubes
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = 
            waypoint.GetGridPos().x + // get the grid position from waypoint script
            "," + 
            waypoint.GetGridPos().y; // get the grid position from waypoint script
        textMesh.text = labelText; // label on top of cube
        gameObject.name = labelText; // name in inspector and hierarchy
    }
}
