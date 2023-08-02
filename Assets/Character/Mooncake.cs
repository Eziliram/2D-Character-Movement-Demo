using System.Collections.Generic;
using UnityEngine;

public class Mooncake : Character {
    private List<State> states = new List<State>();

    [Header("Ground behaviours")]
    public Idle idle;

    private void Awake() {
        SetupStateSystem();
        // SetupCharacter();
    }

    /**
     * Function to setup State System
     * by initialising each state and set an initial state to the State Machine
     F*/
    private void SetupStateSystem() {
        stateMachine = new StateMachine();

        // Initialise state behaviours
        idleState = new IdleState(idle);

        // Add states to list
        states.AddRange(new List<State> {
            idleState,
        });

        // Initialize each state by assigning the state machine and character to it
        states.ForEach(state => {
            state.Initialize(stateMachine, this);
        });

        // Initialize the state machine with the Idle state
        stateMachine.SetState(idleState);
    }

    /**
     * Function to setup Character
     */
    // private void SetupCharacter() {
    //     // Setup initial character properties
    //     body.drag = walk.hasDrag ? 0f : 20f;
    //     body.gravityScale = initialGravityScale;
    // }
}
