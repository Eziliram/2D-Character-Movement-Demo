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

        // TODO: Transition to Walk state if movement input detected
    }

    public override void Exit() {
        base.Exit();
    }
}
