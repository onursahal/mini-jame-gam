using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    private Renderer rend;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend == null) {
            Debug.LogError("Renderer component missing on this GameObject.");
        }   
    }
    // Update is called once per frame
    void Update()
    {
        if (rend != null)
        {
            // Calculate offset and wrap it within 0 and 1 for tiling textures.
            float offset = Time.time * scrollSpeed;
            rend.material.mainTextureOffset = new Vector2(offset, 0);
        }
    }
}
