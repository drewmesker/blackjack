using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public CardScript cardScript;
    public Cards cards;

    public int cardIndex = 0;

    public int handValue;

    public GameObject[] hand;
    // Start is called before the first frame update
    public void StartHand()
    {
        GetCard();
        GetCard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetCard()
    {
        int cardValue = cards.Deal(hand[cardIndex].GetComponent<CardScript>());
        hand[cardIndex].GetComponent<Renderer>().enabled = true;
        handValue += cardValue;
        cardIndex++;
        return handValue;
    }

    public void ResetHand()
    {
        for(int i = 0; i < hand.Length; i++)
        {
            hand[i].GetComponent<CardScript>().ResetCard();
            hand[i].GetComponent<Renderer>().enabled = false;
        }
        cardIndex = 0;
        handValue = 0;
    }
}
