using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckScript : MonoBehaviour
{
    public Sprite[] cardSprites;
    int[] cardValues = new int[53];
    int curr = 0;

    void Start()
    {
        GetCardValues();
    }

    void GetCardValues()
    {
        int num = 0;
        for (int i = 0; i < cardSprites.Length; i++)
        {
            num = i;
            num %= 13;
            if(num > 10 || num == 0)
            {
                num = 10;
            }
            cardValues[i] = num++;
        }
    }


    // Sourced from Kaiser YouTube video
    public void Shuffle()
    {
        for(int i = cardSprites.Length -1; i > 0; --i)
        {
            int j = Mathf.FloorToInt(Random.Range(0.0f, 1.0f) * cardSprites.Length - 1) + 1;
            Sprite faceCard = cardSprites[i];
            cardSprites[i] = cardSprites[j];
            cardSprites[j] = faceCard;

            int value = cardValues[i];
            cardValues[i] = cardValues[j];
            cardValues[j] = value;
        }
        curr = 1;
    }

    public int Deal(CardScript cardScript)
    {
        cardScript.SetSprite(cardSprites[curr]);
        cardScript.SetValue(cardValues[curr++]);
        return cardScript.returnValue();
    }

    public Sprite GetCard()
    {
        return cardSprites[0];
    }
}
