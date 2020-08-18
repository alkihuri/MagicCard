using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<Sprite> cardSpriteList;
    [SerializeField] GameObject player, npc;
    PlayerLogic playerLogic, npcLogic;
    [SerializeField] float howManyCard;
    [SerializeField] Text playerScores, npcScores;
    void Start()
    {
        howManyCard = 3; 
        if (player != null && npc != null)
        {
            playerLogic = player.GetComponent<PlayerLogic>();
            npcLogic = npc.GetComponent<PlayerLogic>();
        }
        SetCardToPlayers();
    }
  
    public void  SetCardToPlayers()
    {
        if(player!=null && npc!= null)
        {
            playerLogic.cardList = GetNewCardList();
            npcLogic.cardList = GetNewCardList();
            
            playerLogic.PutOnTable();
            npcLogic.PutOnTable();
        }
        else
        {
            Debug.Log("Set npc and player object");
        }
    }

 

    public List<Card> GetNewCardList()
    {

        List<Card> newCardList = new List<Card>();

        for(int i =0;i <howManyCard; i++)
        {
            newCardList.Add(new Card(cardSpriteList[Random.Range(0,3)])); 
        }

        return newCardList;

    }
    // Update is called once per frame

    private void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Card").Length < 1)
        {
            SetCardToPlayers();
        }

        npcScores.text = "NPC Scores = " + npc.GetComponent<PlayerLogic>().scores;

        playerScores.text = "Player Scores = " + player.GetComponent<PlayerLogic>().scores;

    }

}
