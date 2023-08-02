using UnityEngine;

public class StateMachine {
    public State currentState { get; private set; }

    /**
   * Function to set the current state to the new state
   */
    public void SetState(State newState) {
        if (newState == null) {
            Debug.LogWarning("Attempting to set a null state!");
            return;
        }

        if (currentState != null) {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter();
    }

    /**
     * Function to update the state based on the current state
     */
    public void Update() {
        if (currentState != null) {
            currentState.Execute();
        }
    }
}
