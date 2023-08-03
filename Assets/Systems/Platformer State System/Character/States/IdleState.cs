using UnityEngine;

public class IdleState : State {
    public Idle idle;

    // Initialise Idle State with Behaviour
    public IdleState(Idle _idle) {
        idle = _idle;
    }

    public override void Enter() {
        animator.Play(idle.animation);
    }

    public override void Execute() {
        // Do nothing if in Idle state

        if (character.groundDetector.isOnTheGround) {
            // Transition to Walk state if movement input detected
            if (Mathf.Abs(character.inputController.movement.x) > 0.1f) {
                stateMachine.SetState(character.walkState);
                return;
            }
        }
    }

    public override void Exit() {
        base.Exit();
    }
}
