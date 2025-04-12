using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform cameraTransform;
    public float parallaxEffect = 0.5f;

    private float spriteWidth;
    private Vector3 lastCameraPosition;

    void Start()
    {
        lastCameraPosition = cameraTransform.position;
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();
        spriteWidth = sprite.bounds.size.x;
    }

    void LateUpdate()
    {
        float deltaX = cameraTransform.position.x - lastCameraPosition.x;
        transform.position += new Vector3(deltaX * parallaxEffect, 0, 0);
        lastCameraPosition = cameraTransform.position;

        foreach (Transform child in transform)
        {
            float camDistance = cameraTransform.position.x - child.position.x;

            if (camDistance > spriteWidth)
            {
                child.position += new Vector3(spriteWidth * 2, 0, 0);
            }
            else if (camDistance < -spriteWidth)
            {
                child.position -= new Vector3(spriteWidth * 2, 0, 0);
            }
        }
    }
}
