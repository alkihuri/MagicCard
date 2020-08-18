using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    
     public Sprite _cardSprite;
     public float _power;
     public string _name;

  

    public Card(Sprite sp, float pow, string name)
    {
        _cardSprite = sp;
        _power = pow;
        _name = name;
    }
    public Card(Sprite sp)
    {
        _cardSprite = sp;
        _power = System.Convert.ToSingle(sp.name.Split('_')[1]);
        _name = sp.name;
    }

   
    private void Update()
    {
       
    }

    

}
