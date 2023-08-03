using UnityEngine;

public class Character : MonoBehaviour {
    public string characterName;
    public Rigidbody2D body;
    public Vector2 position => transform.position;
    public bool isFacingLeft;
    public float initialGravityScale = 1.5f;

    public StateMachine stateMachine;

    public Pixelator animator;
    public SpriteRenderer spriteRenderer;

    [HideInInspector] public InputController inputController;
    [HideInInspector] public GroundDetector groundDetector;

    //*** Character behaviour states ***//
    // Ground states
    public IdleState idleState;
    public WalkState walkState;

    public float velocityX {
        get {
            return body.velocity.x;
        }
        set {
            body.velocity = new Vector2(value, body.velocity.y);
        }
    }

    public float velocityY {
        get {
            return body.velocity.y;
        }
        set {
            body.velocity = new Vector2(body.velocity.x, value);
        }
    }

    private void Awake() {
        // Instantiate controllers
        inputController = FindObjectOfType<InputController>();

        // Instantiate utility components
        groundDetector = FindObjectOfType<GroundDetector>();

        // Assign character to input controller
        if (inputController != null) {
            inputController.AssignCharacter(this);
        }
    }

    private void Update() {
        /**
         * This will execute the implementation of function Execute() of the current state on each frame.
         * Note: State Enter() and Exit() is called on stateMachine.SetState(state)
         */
        stateMachine.currentState.Execute();
    }

    /**
     * Function to set the character sprite direction based on the direction it is moving
     */
    public void SetFaceDirection(float hInput) {
        if (hInput > 0) {
            isFacingLeft = true;
        } else if (hInput < 0) {
            isFacingLeft = false;
        }

        FlipCharacterDirection();
    }

    /**
     * Function to flip the character sprite direction
     */
    public void FlipCharacterDirection() {
        spriteRenderer.flipX = isFacingLeft;
    }
}
