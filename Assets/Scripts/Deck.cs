using UnityEngine;
using UnityEngine.EventSystems; 
using System.Collections.Generic;

public class Deck : MonoBehaviour, IPointerClickHandler
{
    public GameObject cardPrefab;

    public Transform wastePile;

    private Stack<GameObject> deckStack = new Stack<GameObject>();

    void Start()
    {
        SetupDeck();
    }

    void SetupDeck()
    {
        for (int i = 0; i < 24; i++)
        {
            GameObject card = Instantiate(cardPrefab);
            card.transform.SetParent(this.transform);
            card.SetActive(false);

            deckStack.Push(card);
        }

        Debug.Log("Колода готова. Карт: " + deckStack.Count);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (deckStack.Count > 0)
        {
            GameObject cardToDeal = deckStack.Pop();
            cardToDeal.SetActive(true);
            cardToDeal.transform.SetParent(wastePile);

            cardToDeal.transform.localPosition = Vector3.zero;
            cardToDeal.transform.localScale = Vector3.one;

            Debug.Log("Выдана карта. В колоде осталось: " + deckStack.Count);
        }
        else
        {
            Debug.Log("Колода пуста");
        }
    }
}