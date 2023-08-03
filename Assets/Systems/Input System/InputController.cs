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

    private void Update() {
        ResetInputs();
        HandleInputs();
    }

    public void AssignCharacter(Character _character) {
        character = _character;
    }

    private void HandleInputs() {
        movement = input.actions["Move"].ReadValue<Vector2>();
    }

    private void ResetInputs() {
        movement = default;
    }
}
