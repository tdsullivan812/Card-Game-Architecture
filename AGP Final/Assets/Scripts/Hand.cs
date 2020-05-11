using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : ICardGameElement
{
    public List<Card> cardsInHand;
    //public List<RectTransform> handTransforms;

    public Hand()
    {
        cardsInHand = new List<Card>();

    }

    public Card PlayFromHand(Card cardToPlay, CardGame gameToPlayIn)
    {

        cardsInHand.Remove(cardToPlay);
        gameToPlayIn.Play(cardToPlay);

            
       
        return cardToPlay;
    }

    public Card PlayFromHand (Card cardToPlay, CardGame gameToPlayIn, Discard receivingDiscard)
    {
        cardsInHand.Remove(cardToPlay);
        receivingDiscard.Add(cardToPlay);
        gameToPlayIn.Play(cardToPlay);

        return cardToPlay;
    }



    public Card Discard(Card cardToDiscard, Discard receivingDiscard)
    {
        cardsInHand.Remove(cardToDiscard);

        receivingDiscard.Add(cardToDiscard);


        return cardToDiscard;
    }

    public Card Add(Card cardToAdd, int index = -1)
    {
        if (index < 0)
        {
            cardsInHand.Add(cardToAdd);
        }
        else
        {
            cardsInHand.Insert(index, cardToAdd);
        }

        return cardToAdd;
    }

    public Card Remove(Card cardToRemove)
    {
        cardsInHand.Remove(cardToRemove);
        return cardToRemove;
    }
}
