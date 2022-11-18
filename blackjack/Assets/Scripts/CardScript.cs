using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{

    public int value = 0;

    public int returnValue()
    {
        return value;
    }

    public void SetValue(int newV)
    {
        value = newV;
    }

    public string getNameOfSprite()
    {
        return GetComponent<SpriteRenderer>().sprite.name;
    }

    public void SetSprite(Sprite newSprite)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    public void ResetCard()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.Find("DeckCard").GetComponent<DeckScript>().GetCard();
        value = 0;
    }
}
