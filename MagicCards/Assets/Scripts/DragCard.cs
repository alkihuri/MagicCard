using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCard : MonoBehaviour
{
    // Start is called before the first frame update
    public  GameObject _player, _npc;
    private void Start()
    {
        _npc = GameObject.FindGameObjectWithTag("NPC");
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ScoreToPlayer(float score)
    {
        _player.GetComponent<PlayerLogic>().scores += score;
    }
    public void ScoreToNpc(float score)
    {
        _npc.GetComponent<PlayerLogic>().scores += score;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Card")
        {
            ScoreToNpc(collision.gameObject.GetComponent<Card>()._power);
            ScoreToPlayer(GetComponent<Card>()._power);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    private void OnMouseDrag()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 objPostion = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPostion -  new Vector3(0, 0, Camera.main.transform.position.z);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
