using System.Collections.Generic;
using UnityEngine;

public class Mooncake : Character {
    private List<State> states = new List<State>();

    // Ground states
    private Idle idle;
    private Walk walk;

    // Abilities
    private Jump jump;

    private void Start() {
        SetupStateSystem();
        SetupAbilities();
        SetupCharacter();
    }

    /**
     * Function to setup State System
     * by initialising each state and set an initial state to the State Machine
     F*/
    private void SetupStateSystem() {
        // Instantiate ground states
        idle = FindObjectOfType<Idle>();
        walk = FindObjectOfType<Walk>();

        // Instantiate abilities
        jump = FindObjectOfType<Jump>();

        stateMachine = new StateMachine();

        // Initialise state behaviours
        idleState = new IdleState(idle);
        walkState = new WalkState(walk);
        jumpState = new JumpState(jump);

        // Add states to list
        states.AddRange(new List<State> {
            idleState,
            walkState,
            jumpState,
        });

        // Initialize each state by assigning the state machine and character to it
        states.ForEach(state => {
            state.Initialize(stateMachine, this);
        });

        // Initialize the state machine with the Idle state
        stateMachine.SetState(idleState);
    }

    /**
     * Function to setup Abilities
     */
    private void SetupAbilities() {
        abilitiesController.Initialize(this);
    }

    /**
     * Function to setup Character
     */
    private void SetupCharacter() {
        // Setup initial character properties
        body.drag = walk.hasDrag ? 0f : 20f;
        body.gravityScale = initialGravityScale;
    }
}
