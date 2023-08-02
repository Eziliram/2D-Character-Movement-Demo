using UnityEngine;

/**
 * State class
 *
 * The State class defines the behaviour of a specific state
 */
public abstract class State : IState {
    protected Character character;
    protected StateMachine stateMachine;
    protected Pixelator animator => character.animator;

    /**
    * Function to assign the State Machine and Character for a specific state
    */
    public void Initialize(StateMachine _stateMachine, Character _character) {
        stateMachine = _stateMachine;
        character = _character;
    }

    public virtual void Enter() { }

    public virtual void Execute() { }

    public virtual void Exit() { }
}
