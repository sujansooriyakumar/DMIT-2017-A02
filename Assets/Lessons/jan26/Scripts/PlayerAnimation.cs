using NUnit.Framework;
using NUnit.Framework.Internal;
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
    private PlayerAnimationState currentState = PlayerAnimationState.IDLE_DOWN;
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

        StopAllCoroutines();
        StartCoroutine(PlayAnimation(animationData));
    }

    public void SetAnimationState(Vector2 moveDirection)
    {
        if (moveDirection.y < 0)
        {
            currentState = PlayerAnimationState.WALK_DOWN;
        }
        else if (moveDirection.y > 0)
        {
            currentState = PlayerAnimationState.WALK_UP;
        }
        else if (moveDirection.x > 0)
        {
            currentState = PlayerAnimationState.WALK_LEFT;

        } 

        else if(moveDirection.x < 0)
        {
            currentState = PlayerAnimationState.WALK_RIGHT;

        }

        if(moveDirection == Vector2.zero)
        {
            currentState = GetIdleState(currentState);
        }

        InitializeAnimation(animationDictionary[currentState]);


    }

    private PlayerAnimationState GetIdleState(PlayerAnimationState currentState)
    {
        PlayerAnimationState state = PlayerAnimationState.IDLE_UP;

        switch (currentState)
        {
            case PlayerAnimationState.WALK_UP: 
                state = PlayerAnimationState.IDLE_UP;
                break;
            case PlayerAnimationState.WALK_DOWN: 
                state = PlayerAnimationState.IDLE_DOWN;
                break;
            case PlayerAnimationState.WALK_LEFT:
                state = PlayerAnimationState.IDLE_LEFT;
                break;
            case PlayerAnimationState.WALK_RIGHT:
                state = PlayerAnimationState.IDLE_RIGHT;
                break;
            default:
                break;
        }

        return state;

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
