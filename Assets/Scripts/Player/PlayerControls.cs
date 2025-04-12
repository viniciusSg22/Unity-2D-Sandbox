using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    private InputActionReference moveActionToUse;
    [SerializeField]
    private float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = moveActionToUse.action.ReadValue<Vector2>();
        moveDirection.y = 0f;
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
