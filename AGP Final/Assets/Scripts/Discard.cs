using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discard : ICardGameElement
{

   
    public List<Card> cardsInDiscard;

    public Discard()
    {
        cardsInDiscard = new List<Card>();
    }

    public Card Remove(Card cardToRemove)
    {
        
        cardsInDiscard.Remove(cardToRemove);
        return cardToRemove;
    }


    public Card Add(Card cardToAdd, int target = -1)
    {
        if (target == -1)
        {
            cardsInDiscard.Add(cardToAdd);
        }
        else
        {
            cardsInDiscard.Insert(target, cardToAdd);
        }

        return cardToAdd;
    }

}
