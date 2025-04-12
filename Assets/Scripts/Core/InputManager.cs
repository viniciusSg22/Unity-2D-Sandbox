using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerController_2 player;
    public float moveSpeed = 5f;

    private Vector2 movement;

    void Update()
    {
        // Gamepad ou teclado usando Input System
        movement = Gamepad.current != null ? Gamepad.current.leftStick.ReadValue() : KeyboardInput();

        Vector3 move = new Vector3(movement.x, 0, 0) * moveSpeed * Time.deltaTime;
        player.transform.position += move;
    }

    Vector2 KeyboardInput()
    {
        float x = 0f;
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed) x -= 1f;
        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed) x += 1f;
        return new Vector2(x, 0);
    }
}
