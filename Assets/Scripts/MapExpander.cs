using System.Collections.Generic;
using UnityEngine;

public class MapExpander : MonoBehaviour
{
    public Camera cam;
    public GameObject background; // Base background prefab; must have a SpriteRenderer, Collider2D, and Tag "Background"
    public float overlapFactor = 0.9f; // To avoid precision issues

    private Vector3 tileSize; // Cached size of a single tile
    private HashSet<Vector2> spawnedCells = new HashSet<Vector2>(); // Track spawned grid cell centers

    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        if (background != null)
        {
            tileSize = background.transform.localScale;
        }

    }

    void Update()
    {
        Bounds camBounds = GetCameraWorldBounds(cam);
        ExpandBackground(camBounds);
    }

    // Returns the camera's view bounds in world space.
    Bounds GetCameraWorldBounds(Camera camera)
    {
        float cameraHeight = camera.orthographicSize * 2;
        float cameraWidth = cameraHeight * camera.aspect;
        return new Bounds(camera.transform.position, new Vector3(cameraWidth, cameraHeight, 0));
    }

    // Spawns background tiles in a grid covering the camera's view.
    void ExpandBackground(Bounds camBounds)
    {
        float startX = Mathf.Floor(camBounds.min.x / tileSize.x) * tileSize.x;
        float endX = Mathf.Ceil(camBounds.max.x / tileSize.x) * tileSize.x;
        float startY = Mathf.Floor(camBounds.min.y / tileSize.y) * tileSize.y;
        float endY = Mathf.Ceil(camBounds.max.y / tileSize.y) * tileSize.y;

        for (float x = startX; x < endX; x += tileSize.x)
        {
            for (float y = startY; y < endY; y += tileSize.y)
            {
                // Calculate the center of this grid cell.
                Vector3 cellCenter = new Vector3(x + tileSize.x * 0.5f, y + tileSize.y * 0.5f, 0);
                Vector2 cellKey = new Vector2(cellCenter.x, cellCenter.y);
                if (!spawnedCells.Contains(cellKey))
                {
                    Instantiate(background, cellCenter, background.transform.rotation);
                    spawnedCells.Add(cellKey);
                    Debug.Log("Spawned background at cell center: " + cellCenter);
                }
            }
        }
    }
}
