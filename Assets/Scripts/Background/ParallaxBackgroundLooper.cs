using UnityEngine;

public class ParallaxBackgroundLooper : MonoBehaviour
{
    public Transform cameraTransform;
    public float parallaxEffect = 0.5f;

    private float spriteWidth;
    private Vector3 lastCameraPosition;
    private bool initialized = false;

    public void Initialize()
    {
        lastCameraPosition = cameraTransform.position;
        initialized = true;
    }

    void Start()
    {
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();
        spriteWidth = sprite.bounds.size.x;
    }

    void LateUpdate()
    {
        if (!initialized) return;

        float deltaX = cameraTransform.position.x - lastCameraPosition.x;
        transform.position += new Vector3(deltaX * parallaxEffect, 0, 0);
        lastCameraPosition = cameraTransform.position;

        foreach (Transform child in transform)
        {
            float camDistance = cameraTransform.position.x - child.position.x;

            if (camDistance > spriteWidth)
                child.position += new Vector3(spriteWidth * 2f, 0f, 0f);
            else if (camDistance < -spriteWidth)
                child.position -= new Vector3(spriteWidth * 2f, 0f, 0f);
        }
    }
}
