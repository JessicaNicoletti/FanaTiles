using UnityEngine;

[System.Serializable]
public class AnimationEvent 
{
    [SerializeField] private float delayTime;
    [SerializeField] private AnimationElement element;

    public float getDelayTime { get { return delayTime; } }
    public float getTweenTime { get { return element.GetTweenTime(); } }

    public void InvokeAnimation()
    {
        element.SetAnimation(delayTime);
    }

    public void ResetAnimation()
    {
        element.ResetAnimation();
    }

  
}
