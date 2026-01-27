using UnityEngine;

[CreateAssetMenu(fileName = "Animation", menuName = "Animation")]
public class AnimationData : ScriptableObject
{
    public string animationName;
    public Sprite[] frames;
    public float frameDelay;
}