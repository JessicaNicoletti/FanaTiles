using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationManager : MonoBehaviour
{
    [SerializeField] private AnimationEvent[] animationEvents;
    [SerializeField] private AnimationEvent[] animationTransition;

    public float getAnimatonInTime { get { return GetAnimationTime(animationEvents); } }
    public float getAnimationOutTime { get { return GetAnimationTime(animationTransition); } }


    public void PlayInAnimation()
    {
        for (int i = 0; i < animationEvents.Length; i++)
        {
            animationEvents[i].InvokeAnimation();
        }
    } 

    public void PlayOutAnimation()
    {
        for (int i = 0; i < animationTransition.Length; i++)
        {
            animationTransition[i].InvokeAnimation();
        }
    }
    public void ResetAnimationTransistion()
    {
        for (int i = 0; i < animationTransition.Length; i++)
        {
            animationTransition[i].ResetAnimation();
        }
    }

    public float GetAnimationTime(AnimationEvent[] _array)
    {
        float delay = 0;
        float tweenTime = 0;

        for (int i = 0; i < _array.Length; i++)
        {
            if(_array[i].getDelayTime > delay)
            {
                delay = _array[i].getDelayTime;
            }  
            
            if(animationEvents[i].getTweenTime > tweenTime)
            {
                tweenTime = _array[i].getTweenTime;
            }
        }

        return (delay + tweenTime);

    }
}

