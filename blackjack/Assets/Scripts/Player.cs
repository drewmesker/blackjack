using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public CardScript cardScript;
    public DeckScript cards;

    public int cardIndex = 0;

    public int handValue = 0;
    private int money = 1000;
    List<CardScript> aces = new List<CardScript>();

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
        AceCheck();
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
        aces = new List<CardScript>();
    }

    public void AceCheck()
    {
        foreach (CardScript ace in aces)
        {
            if(handValue + 10 < 22 && ace.GetValueOfCard() == 1)
            {
                ace.SetValue(11);
                handValue += 10;
            } else if (handValue > 21 && ace.GetValueOfCard() == 11)
            {
                ace.SetValue(1);
                handValue -= 10;
            }
        }
    }

    public void AdjustMoney(int amount)
    {
        money += amount;
    }
    public int GetMoney()
    {
        return money;
    }
}
