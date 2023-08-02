using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Pixel Animation", menuName = "Pixelator/New Pixel Animation")]
public class PixelAnimation : ScriptableObject {
    public List<Sprite> frames;
}