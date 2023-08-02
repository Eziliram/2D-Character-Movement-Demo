using UnityEngine;

public class Pixelator : MonoBehaviour {
    public SpriteRenderer spriteRenderer;
    public PixelAnimation currentAnimation;

    public float frameTime = 0.1f; // The speed at which the animation will play
    private int currentFrameIndex = 0; // Set default current frame to first frame in animation
    private float timeSinceLastFrameChange;

    private void Update() {
        Animate();
    }

    /**
     * Function to play an animation
     */
    public void Play(PixelAnimation animation/*, bool shouldLoop = true*/) {
        if (animation == null) {
            Debug.LogError($"Error: Pixel Animation '{animation.name}' is null. Make sure it has been setup correctly in the inspector.");
            return;
        }

        // Setup new animation
        currentAnimation = animation;
    }

    /**
     * Function to display each frame of the currently set animation based on it's frame time
     */
    private void Animate() {
        // If no animation has been set, do nothing
        if (currentAnimation == null) return;

        // Keep track of the time since the last frame change
        timeSinceLastFrameChange += Time.deltaTime;

        //INFO:
        // This while loop checks if enough time has passed to show the next frame,
        // and if so, updates the current frame index and subtracts the frame time
        // from the timeSinceLastFrameChange variable. This loop ensures that we show as
        // many frames as necessary to catch up with the elapsed time since the last
        // frame was rendered. If the current frame index has reached the end of the
        // frames array, it is reset to 0 to start the animation over.
        while (timeSinceLastFrameChange >= frameTime) {
            timeSinceLastFrameChange -= frameTime;
            currentFrameIndex++; // Go to next frame

            // Start the animation from the beginning if the end of the array has been reached
            if (currentFrameIndex >= currentAnimation.frames.Count/* && loop*/) {
                currentFrameIndex = 0;
            }

            // Update the sprite frame
            spriteRenderer.sprite = currentAnimation.frames[currentFrameIndex];
        }
    }

    /**
     * Function to reset the animation and start from the beginning
     */
    public void Reset() {
        currentFrameIndex = 0;
        timeSinceLastFrameChange = 0.0f;
    }

    /**
     * Function to stop the animation that is currently playing
     */
    public void Stop() {
        currentAnimation = null;
    }
}
