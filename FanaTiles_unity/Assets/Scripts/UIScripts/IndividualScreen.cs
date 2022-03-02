using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndividualScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup[] groups;
    private AnimationManager animationManager;
    private GraphicRaycaster graphicRaycaster;

    public void InitializeScreen()
    {
        animationManager = GetComponent<AnimationManager>();
        graphicRaycaster = GetComponent<GraphicRaycaster>();
    }


    //Play intro animations;
    public virtual void ShowScreen()
    {
        animationManager.ResetAnimationTransistion();
        ResetCanvasGroup();
        animationManager.PlayInAnimation();
        graphicRaycaster.enabled = true;        
    }

    //Play transistion animations;
    public virtual void HideScreen()
    {        
        animationManager.PlayOutAnimation();
        graphicRaycaster.enabled = false;
    }

    public void ResetCanvasGroup()
    {
        for (int i = 0; i < groups.Length; i++)
        {
            groups[i].alpha = 1;
        }
      
    }
  
}
