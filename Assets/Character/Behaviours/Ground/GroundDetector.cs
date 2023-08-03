using UnityEngine;

public class GroundDetector : MonoBehaviour {
    public Character character;

    public bool isOnTheGround;
    public LayerMask groundMask;

    public float footDepth = 0f;
    public float footWidth = 0.1f;
    public float groundDepth = 0.01f;

    private Vector2 feetPosition => character.position + (Vector2.down * footDepth);
    private float halfFootWidth => footWidth / 2f;

    private void FixedUpdate() {
        isOnTheGround = IsOnTheGround();
    }

    private bool IsOnTheGround() {
        // Check if any colliders are overlapping with the ground
        Collider2D[] colliders = Physics2D.OverlapAreaAll(GetBottomLeftPoint(), GetTopRightPoint(), groundMask);
        return colliders.Length != 0;
    }

    private void OnDrawGizmos() {
        DrawFootLine();
        DrawGroundCheckBox();
    }

    private void DrawFootLine() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine((feetPosition + Vector2.left * halfFootWidth), (feetPosition + Vector2.right * halfFootWidth));
    }

    private void DrawGroundCheckBox() {
        Utils.DrawBox(new Rect(GetBottomLeftPoint(), GetTopRightPoint() - GetBottomLeftPoint()));
    }

    private Vector2 GetBottomLeftPoint() {
        return feetPosition + (Vector2.left * halfFootWidth) + (Vector2.down * groundDepth);
    }

    private Vector2 GetTopRightPoint() {
        return feetPosition + (Vector2.right * halfFootWidth) + (Vector2.up * groundDepth);
    }
}
