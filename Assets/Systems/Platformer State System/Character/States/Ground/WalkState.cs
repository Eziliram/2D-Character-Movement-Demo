using UnityEngine;

public class WalkState : State {
    public Walk walk;

    private float hInput;
    private float force;

    // Initialise Walk State with Behaviour
    public WalkState(Walk _walk) {
        walk = _walk;
    }

    public override void Enter() {
        animator.Play(walk.animation);
    }

    public override void Execute() {
        hInput = character.inputController.movement.x;
        force = hInput * walk.force;

        if (character.groundDetector.isOnTheGround) {
            // Execute Walk if movement input detected
            if (Mathf.Abs(hInput) > 0.1f) {
                character.velocityX = force;
                character.SetFaceDirection(force);
                return;
            }

            // Else transition to Idle state if no input detected
            stateMachine.SetState(character.idleState);
        }
    }

    public override void Exit() {
        base.Exit();
    }
}
