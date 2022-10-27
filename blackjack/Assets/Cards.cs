using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    public Sprite[] Card;
    int[] cards = new int[53];
    int curr;   



    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void getCards()
    {
        int n = 0;

        for (int i = 0; i < Card.Length; i++)
        {
            n = i;
            n %= 13;
            if(n == 0 || n > 10)
            {
                n = 10;
            }

            cards[i] = n++;

        }
        curr = 1;
    }

    void shuffleDeck()
    {
        for(int i = Card.Length - 1; i > 0; --i)
        {
            int w = Mathf.FloorToInt(Random.Range(0.0f, 1.0f) * Card.Length - 1) +1;
            Sprite faceCard = Card[i];
            Card[w] = faceCard;
            int v = cards[i];
            cards[i] = cards[w];
            cards[w] = v;
        }
    }
}
