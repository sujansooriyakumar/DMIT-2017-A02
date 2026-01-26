using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TopDownPlayerMovement))]
public class PlayerAnimation : MonoBehaviour
{
    public List<AnimationStateData> animations = new List<AnimationStateData>();
    private SpriteRenderer sr;
    bool isPlaying = false;

    private Dictionary<PlayerAnimationState, AnimationData> animationDictionary = new Dictionary<PlayerAnimationState, AnimationData>();

    private void Start()
    {
        InitializeDictionary();
        sr = GetComponent<SpriteRenderer>();
        TopDownPlayerMovement playerMovement = GetComponent<TopDownPlayerMovement>();
        playerMovement.OnMove += SetAnimationState;


    }
    public void InitializeDictionary()
    {
        foreach (AnimationStateData animationStateData in animations)
        {
            animationDictionary.Add(animationStateData.state, animationStateData.animation);
        }
        }

    public void InitializeAnimation(AnimationData animationData)
    {
        StartCoroutine(PlayAnimation(animationData));
    }

    public void SetAnimationState(Vector2 moveDirection)
    {
        if(moveDirection.y < 0)
        {
            InitializeAnimation(animationDictionary[PlayerAnimationState.WALK_DOWN]);
        }
        PlayerAnimationState currentState;
        // using a switch case, check for the current state of the player
        // y > 0 = WALK_UP
        // x < 0 = WALK_LEFT


        // how do we handle idle animations?

        // InitializeAnimation(animationDictionary[currentState]);
    }

    private IEnumerator PlayAnimation(AnimationData animation)
    {
        isPlaying = true;
        sr.sprite = animation.frames[0];
        int frameCount = animation.frames.Length;
        int frameIndex = 0;

        while (isPlaying)
        {
            yield return new WaitForSeconds(animation.frameDelay);
            frameIndex++;
            if (frameIndex >= animation.frames.Length) frameIndex = 0;
            sr.sprite = animation.frames[frameIndex];

            yield return null;
        }
        yield return null;
    }

    public void StopPlaying()
    {
        isPlaying = false;
    }
}

[CreateAssetMenu(fileName = "Animation", menuName = "Animation")]
public class AnimationData : ScriptableObject
{
    public string animationName;
    public Sprite[] frames;
    public float frameDelay;
}

public enum PlayerAnimationState
{
    WALK_UP,
    WALK_DOWN,
    WALK_LEFT,
    WALK_RIGHT,
    IDLE_UP,
    IDLE_DOWN,
    IDLE_LEFT,
    IDLE_RIGHT
}

[Serializable]
public class AnimationStateData
{
    public PlayerAnimationState state;
    public AnimationData animation;
}
