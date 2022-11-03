using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button dealbtn;
    public Button hitbtn;
    public Button standbtn;
    public Button splitbtn;
    public Button dblbtn;

    public Player player;
    public Player dealer;

    public GameObject hideCard;

    
    // Start is called before the first frame update
    void Start()
    {
        DealClicked();
        //hitbtn.onClick.AddListener(() => HitClicked());
        //standbtn.onClick.AddListener(() => StandClicked());
        //splitbtn.onClick.AddListener(() => SplitClicked());
        //dblbtn.onClick  .AddListener(() => DoubleClicked());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DealClicked()
    {
        Debug.Log("Test");
        
        player.ResetHand();
        dealer.ResetHand();
        
        
        GameObject.Find("Deck").GetComponent<Cards>().shuffleDeck();
        player.StartHand();
        dealer.StartHand();
        
        
        hideCard.GetComponent<Renderer>().enabled = true;
        dealbtn.gameObject.SetActive(false);

    }
}
