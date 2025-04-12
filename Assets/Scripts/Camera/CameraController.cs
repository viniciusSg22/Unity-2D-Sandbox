using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 posOffset;
    public float smooth;

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + posOffset, smooth * Time.deltaTime);
    }
}
