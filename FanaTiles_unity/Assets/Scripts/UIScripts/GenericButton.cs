using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class GenericButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public bool interactable = true;
    [Space(5)]
    [SerializeField] private UnityEvent onClick;
    private Tweener tweener;
 
    public void OnClickDownAnimation()
    {
        tweener?.Kill();
        tweener = transform.DOScale(0.9f, 0.2f);
    }

    public void OnClickUpAnimation()
    {
        tweener?.Kill();
        tweener = transform.DOScale(1, 0.2f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (interactable)
        {
            OnClickDownAnimation();
        }               
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (interactable)
        {
            onClick.Invoke();
            OnClickUpAnimation();
        }     
    }

}
