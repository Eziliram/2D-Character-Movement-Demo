using UnityEngine;

/**
 * Abilities Controller
 *
 * The Abilities Controller manages the transitions between abilities
 */
public class AbilitiesController : MonoBehaviour {
    private Character character;

    public bool isJumping;
    public float horizontalForceDecayFactor = 0.5f;

    private float hInput;
    private float force;

    public void Initialize(Character _character) {
        character = _character;

        // Setup events
        character.inputController.JumpAction += ExecuteJumpAbility;
    }

    private void ExecuteJumpAbility() {
        if (character.groundDetector.isOnTheGround && !isJumping) {
            isJumping = true;
            character.stateMachine.SetState(character.jumpState);
        }
    }

    /**
     * Function to apply horizontal movement while the player is in the air
     */
    public void ApplyHorizontalMovement() {
        hInput = character.inputController.movement.x;
        force = hInput * character.walkState.walk.force;

        character.velocityX = force;
        character.body.AddForce(Vector2.right * (force * (character.isFacingLeft ? -1 : 1)) * horizontalForceDecayFactor);

        character.SetFaceDirection(force);
    }
}