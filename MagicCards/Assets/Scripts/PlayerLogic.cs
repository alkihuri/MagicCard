using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Card> cardList;
    [Range(1, 100)] public  float scores ;
    void Start()
    {
        scores = 0;
    }

    public void PutOnTable()
    {
        for (int i = 0; i < cardList.Count; i++)
        {
            GameObject cardOnScreen = new GameObject();
            cardOnScreen.tag = "Card";

            cardOnScreen.AddComponent<Card>()._power = cardList[i]._power;
            cardOnScreen.GetComponent<Card>()._name = cardList[i]._name;
            cardOnScreen.GetComponent<Card>()._cardSprite = cardList[i]._cardSprite;

            cardOnScreen.AddComponent<BoxCollider2D>().isTrigger = true;

            cardOnScreen.AddComponent<Rigidbody2D>().gravityScale = 0;

            cardOnScreen.name = transform.name + "_" + cardList[i]._name;
            cardOnScreen.AddComponent<SpriteRenderer>().sprite = cardList[i]._cardSprite;
            if (transform.tag == "Player")
            {
                cardOnScreen.AddComponent<DragCard>();
                cardOnScreen.GetComponent<SpriteRenderer>().sortingOrder++;
            }
            float offsterBetwenCards = 3; 
            Instantiate(cardOnScreen, transform.position + new Vector3(i*1.7F   + offsterBetwenCards, 0,0), Quaternion.identity, transform);
            Destroy(cardOnScreen);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
