using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "MaterialAnimation", order = 1)]
public class MaterialAnimation : ScriptableObject {
    public string animationName;
    public List<Sprite> spriteAnimationSheet;
    public float timeBetweenFrames;
}
