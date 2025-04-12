using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_2 : MonoBehaviour
{
    public Transform spawnPoint;

    [SerializeField]
    private InputActionReference moveActionToUse;
    [SerializeField]
    private float speed;

    public void Initialize()
    {
        if (spawnPoint != null)
            transform.position = spawnPoint.position;
    }

    void Update()
    {
        Vector2 moveDirection = moveActionToUse.action.ReadValue<Vector2>();
        moveDirection.y = 0f;
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}