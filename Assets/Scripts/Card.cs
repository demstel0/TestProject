using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 
using System.Collections.Generic;

[RequireComponent(typeof(CanvasGroup))]
public class Card : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private CanvasGroup canvasGroup;
    private Transform parentToReturnTo = null;
    private Transform rootCanvas = null;
    private List<Transform> stackedCards = new List<Transform>();

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rootCanvas = FindObjectOfType<Canvas>().transform;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        stackedCards.Clear();
        
        parentToReturnTo = this.transform.parent;

        if (parentToReturnTo.GetComponent<VerticalLayoutGroup>() != null)
        {
            int selfIndex = this.transform.GetSiblingIndex();

            for (int i = selfIndex + 1; i < parentToReturnTo.childCount; i++)
            {
                Transform cardBelow = parentToReturnTo.GetChild(i);
                stackedCards.Add(cardBelow);
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        this.transform.SetParent(rootCanvas);
        canvasGroup.blocksRaycasts = false;
        foreach (Transform card in stackedCards)
        {
            card.SetParent(this.transform);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        Transform newParent = this.transform.parent;

        if (newParent == rootCanvas)
        {
            this.transform.SetParent(parentToReturnTo);
            newParent = parentToReturnTo;
        }

      
        foreach (Transform card in stackedCards)
        {
            card.SetParent(newParent);
        }
        stackedCards.Clear();
    }
}