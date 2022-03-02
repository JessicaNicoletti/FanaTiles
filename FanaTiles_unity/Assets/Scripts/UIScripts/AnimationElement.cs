using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
public class AnimationElement : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector2 originalPosition;
    private Vector2 originalSize;
    private Vector3 originalScale;
    private Vector3 originalRotation;   
    private float originalAlpha;
    private Image image;
    private TextMeshProUGUI text;
    private CanvasGroup canvasGroup;
    private GenericButton button;  

    [Header("Move")]
    [SerializeField] private bool move;
    [SerializeField] private Vector2 finalPos;  
    [SerializeField] private float moveTime;
    [SerializeField] private Ease moveEase = Ease.InOutSine;
    private Tweener moveTween;

    [Header("Size")]
    [SerializeField] private bool size;
    [SerializeField] private Vector2 finalSize;
    [SerializeField] private float sizeTime;
    [SerializeField] private Ease sizeEase = Ease.InOutSine;
    private Tweener sizeTween;


    [Header("Scale")]
    [SerializeField] private bool scale;
    [SerializeField] private float finalScale;
    [SerializeField] private float scaleTime;
    [SerializeField] private Ease scaleEase = Ease.InOutSine;
    private Tweener scaleTween;


    [Header("Fade")]
    [SerializeField] private bool fade;
    [SerializeField] private float fadeInRange;
    [SerializeField] private float fadeInTime;
    [SerializeField] private Ease fadeInEase = Ease.InOutSine;
    private Tweener fadeInTween;

    private void Awake()
    {  
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
        originalSize = rectTransform.sizeDelta;
        originalRotation = transform.localEulerAngles;
        originalScale = transform.localScale;

        image = GetComponent<Image>();
        text = GetComponent<TextMeshProUGUI>();
        canvasGroup = GetComponent<CanvasGroup>();
        button = GetComponent<GenericButton>();

        if (image != null)
        {
            originalAlpha = image.color.a;
        }
        else if(text !=null)
        {
            originalAlpha = text.alpha;
        }
        else 
        {
            originalAlpha = canvasGroup.alpha;
        }

    }

    private void OnDisable()
    {
        KillAllTweens();
    }

    public void KillAllTweens()
    {
        sizeTween?.Kill();      
        moveTween?.Kill();
        fadeInTween?.Kill();
        scaleTween?.Kill();        
    }

    public void ResetAnimation()
    {
        if (move)
        {
            rectTransform.anchoredPosition = originalPosition;
        }
        
        rectTransform.sizeDelta = originalSize;
        transform.localEulerAngles = originalRotation;
        transform.localScale = originalScale;



        if (image != null)
        {
            Color temp = image.color;
            temp.a = originalAlpha;
            image.color = temp;
        }
        else if(text != null)
        {
            text.alpha = originalAlpha;
        }
        else
        {
            canvasGroup.alpha = originalAlpha;
        }           
    }


    public void SetAnimation(float _delay)
    {
        if (button != null)
        {
            StartCoroutine(CheckAnimation(_delay));
        }
        
        ResetAnimation();
        KillAllTweens();

        if (size)
        {            
            sizeTween = rectTransform.DOSizeDelta(finalSize, sizeTime).SetUpdate(true).SetEase(sizeEase).SetDelay(_delay);
        }

        if (scale)
        {
            scaleTween = rectTransform.DOScale(finalScale, scaleTime).SetUpdate(true).SetEase(scaleEase).SetDelay(_delay);
        }

        if (fade)
        {
            if (image != null)
            {
                fadeInTween = image.DOFade(fadeInRange, fadeInTime).SetEase(fadeInEase).SetUpdate(true).SetDelay(_delay);
            }
            else if (text != null)
            {                
                fadeInTween = text.DOFade(fadeInRange, fadeInTime).SetEase(fadeInEase).SetUpdate(true).SetDelay(_delay);
            }
            else
            {
                fadeInTween = canvasGroup.DOFade(fadeInRange, fadeInTime).SetEase(fadeInEase).SetUpdate(true).SetDelay(_delay);
            }
            
        }

        if (move)
        {
            moveTween = rectTransform.DOAnchorPos(finalPos, moveTime).SetEase(moveEase).SetUpdate(true).SetDelay(_delay);
        }

    }

    public float GetTweenTime()
    {
        float time = 0;
        
        if(moveTime > time)
        {
            time = moveTime;
        }
        if(sizeTime > time)
        {
            time = sizeTime;
        }
        if(scaleTime > time)
        {
            time = scaleTime;
        }
        if(fadeInTime > time)
        {
            time = fadeInTime;
        }

        return time;
    }
   
    public IEnumerator CheckAnimation(float _delay)
    {
        button.interactable = false;

        float time = _delay + GetTweenTime();

        yield return new WaitForSeconds(time);

        button.interactable = true;
    }
}


