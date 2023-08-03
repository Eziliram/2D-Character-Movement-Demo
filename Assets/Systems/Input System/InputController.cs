using System;
using UnityEngine;
using UnityEngine.InputSystem;

/**
 * Input Controller
 *
 * The Input Controller captures and invokes user input actions
 */
public class InputController : MonoBehaviour {
    protected Character character;

    public PlayerInput input;

    public Vector2 movement;
    public bool isMoving => movement.x != 0;

    public event Action JumpAction;

    public bool jumpPressed;
    public bool jumpHeld;

    private void Update() {
        ResetInputs();
        HandleInputs();
        InvokeAbilities();
    }

    public void AssignCharacter(Character _character) {
        character = _character;
    }

    private void HandleInputs() {
        movement = input.actions["Move"].ReadValue<Vector2>();

        jumpPressed = input.actions["Jump"].WasPressedThisFrame();
        jumpHeld = input.actions["Jump"].IsPressed();
    }

    private void ResetInputs() {
        movement = default;
        jumpPressed = default;
        jumpHeld = default;
    }

    private void InvokeAbilities() {
        // Invoke Jump event
        if (jumpPressed) {
            if (JumpAction != null) {
                JumpAction();
            }
        }
    }
}
