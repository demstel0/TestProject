using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public GameObject cardPrefab;

    public List<Transform> tableauStacks = new List<Transform>();

    public int minCardPerStack;
    public int maxCardPerStack;

    void Start()
    {
        CreateInitialCards();
    }

    void CreateInitialCards()
    {
        foreach (Transform stack in tableauStacks)
        {
            int cardsPerStack = Random.Range(minCardPerStack, maxCardPerStack);
            for (int i = 0; i < cardsPerStack; i++)
            {
                Instantiate(cardPrefab, stack);
            }
        }
    }
}