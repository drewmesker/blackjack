using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button dealBtn;
    public Button hitBtn;
    public Button standBtn;
    public Button betBtn;
    public Button doubleBtn;
    public Button splitBtn;

    // Access the player and dealer's script
    public Player playerScript;
    public Player dealerScript;

    public GameObject HiddenCard;

    int pot = 0;

    public Text scoreText;
    public Text dealerScoreText;
    public Text betsText;
    public Text cashText;
    public Text mainText;
    public Text standBtnText;
    public bool standWasClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        dealBtn.onClick.AddListener(() => DealClicked());
        hitBtn.onClick.AddListener(() => HitClicked());
        standBtn.onClick.AddListener(() => StandClicked());
        betBtn.onClick.AddListener(() => BetClicked());
        doubleBtn.onClick.AddListener(() => DoubleClicked());
        splitBtn.onClick.AddListener(() => SplitClicked());
        playerScript.ResetHand();
        dealerScript.ResetHand();
        
    }

    private void SplitClicked()
    {
        throw new NotImplementedException();
    }

    private void DoubleClicked()
    {
         if (playerScript.cardIndex == 2)
        {
            playerScript.AdjustMoney(-pot);
            cashText.text = "$" + playerScript.GetMoney().ToString();
            pot += (pot * 2);
            betsText.text = "$" + pot.ToString();
            playerScript.GetCard();
            scoreText.text = playerScript.handValue.ToString();
            StandClicked();
        }
        else
        {
            mainText.text = "Cannot Double";
        }
    }

        private void DealClicked()
    {
        playerScript.ResetHand();
        dealerScript.ResetHand();

        dealerScoreText.gameObject.SetActive(false);
        mainText.gameObject.SetActive(false);
        dealerScoreText.gameObject.SetActive(false);

        GameObject.Find("DeckCard").GetComponent<DeckScript>().Shuffle();

        playerScript.StartHand();
        dealerScript.StartHand();
        scoreText.text = playerScript.handValue.ToString();
        dealerScoreText.text = dealerScript.handValue.ToString();

        HiddenCard.GetComponent<Renderer>().enabled = true;
        
        dealBtn.gameObject.SetActive(false);
        hitBtn.gameObject.SetActive(true);
        standBtn.gameObject.SetActive(true);
        standBtnText.text = "Stand";

    }

    private void HitClicked()
    {
        if (playerScript.cardIndex <= 10)
        {
            playerScript.GetCard();
            scoreText.text = playerScript.handValue.ToString();
            if (playerScript.handValue > 20) RoundOver();
        }
    }

    private void StandClicked()
    {
        HiddenCard.GetComponent<Renderer>().enabled = false;
        standWasClicked = true;
        HitDealer();
        
    }

    private void HitDealer()
    {
        while (dealerScript.handValue < 16 && dealerScript.cardIndex < 10)
        {
            dealerScript.GetCard();
            dealerScoreText.text = dealerScript.handValue.ToString();
            RoundOver();
        }
        RoundOver();
    }

    void RoundOver()
    {
         bool roundOver = true;

         if(playerScript.handValue > 21)
         {
            mainText.text = "Dealer wins!";
         }
         else if(dealerScript.handValue > 21)
         {
            mainText.text = "Winner!";
            playerScript.AdjustMoney(pot*2);
         }
         else if(dealerScript.handValue > playerScript.handValue)
         {
            mainText.text = "Dealer wins!";
         }
         else if(playerScript.handValue > dealerScript.handValue)
         {
            mainText.text = "Winner!";
            playerScript.AdjustMoney(pot*2);
         }
         
         else if(playerScript.handValue == dealerScript.handValue)
         {
            mainText.text = "Push.";
            playerScript.AdjustMoney(pot);
         }
         else
         {
            roundOver = false;
         }

        if (roundOver)
        {
            hitBtn.gameObject.SetActive(false);
            standBtn.gameObject.SetActive(false);
            dealBtn.gameObject.SetActive(true);
            mainText.gameObject.SetActive(true);
            dealerScoreText.gameObject.SetActive(true);
            HiddenCard.GetComponent<Renderer>().enabled = false;
            betsText.text = "$0";
            cashText.text = playerScript.GetMoney().ToString();
            pot = 0;
        }
    }

    void BetClicked()
    {
        playerScript.AdjustMoney(-20);
        cashText.text = "$" + playerScript.GetMoney().ToString();
        pot += 20;
        betsText.text = "$" + pot.ToString();
    }

}