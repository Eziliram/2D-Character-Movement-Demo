using UnityEngine;

public class Jump : MonoBehaviour {
    public new PixelAnimation animation;

    public float force = 4f;

    public float maxJumpTime = 0.25f;
    public float minJumpTime = 0.1f;

    public int availableJumps = 1; // Double jump to be implemented

    // Modifiers
    public float lowJumpMultiplier = 1.5f;
}