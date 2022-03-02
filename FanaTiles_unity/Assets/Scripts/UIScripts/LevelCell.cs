using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelCell : MonoBehaviour
{    
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private AnimationElement animationElement;  

    public void ShowCell(int _levelNumber)
    {
        animationElement.SetAnimation(0);
        levelText.text = _levelNumber.ToString();
    }

    public void ResetAnimation()
    {
        animationElement.ResetAnimation();
    }
}
