using UnityEngine;

public class JumpState : State {
    public Jump jump;

    private float startTime;
    private float jumpTime => Time.time - startTime;

    private bool released => jumpTime >= jump.maxJumpTime;

    // Initialise Jump State with Behaviour
    public JumpState(Jump _jump) {
        jump = _jump;
    }

    public override void Enter() {
        animator.Play(jump.animation);
        startTime = Time.time;
    }

    public override void Execute() {
        ApplyHorizontalMovement();

        // Execute Jump on jump input
        if (IsJumping() || IsJumpingHigh()) {
            character.velocityY = jump.force;
            ApplyBouncyJumpBehaviour();
        }

        if (released) {
            // TODO Implement fall and land states
        }
    }

    public override void Exit() {
        base.Exit();
        character.abilitiesController.isJumping = false;
    }

    /**
     * Function to check if player has pressed the jump input
     */
    private bool IsJumping() {
        return character.inputController.jumpPressed;
    }

    /**
     * Function to check if player is holding the jump input
     */
    private bool IsJumpingHigh() {
        return character.inputController.jumpHeld && jumpTime > jump.minJumpTime && jumpTime < jump.maxJumpTime;
    }

    /**
     * Reference function to apply horizontal movement while the player is in the air
     */
    private void ApplyHorizontalMovement() {
        character.abilitiesController.ApplyHorizontalMovement();
    }

    /**
     * Function to apply a more realistic feel
     */
    private void ApplyBouncyJumpBehaviour() {
        character.body.AddForce(Vector2.up * jump.force * (character.velocityY <= 0 ? jump.lowJumpMultiplier : 1) * Time.deltaTime);
    }
}