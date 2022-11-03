using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{

    //value of card
    public int value = 0;

    // Start is called before the first frame update
    public int returnValue()
    {
        return value;
    }

    // Update is called once per frame
    public void setCardValue(int newV)
    {
        value = newV;
    }

    public string GetNameofSprite()
    {
        return GetComponent<SpriteRenderer>().sprite.name;
    }

    public void SetNameofSprite(Sprite newSprite)
    {
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    public void ResetCard()
    {
        //Sprite back = GameObject.Find("DeckController").GetComponent<Cards>().GetCard();
        //gameObject.GetComponent<SpriteRenderer>().sprite = back;
        value = 0;
    }
}
