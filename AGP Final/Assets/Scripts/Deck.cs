using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : ICardGameElement
{
    
    public List<Card> cardsInDeck;

    public Deck()
    {
        cardsInDeck = new List<Card>();
        Shuffle();
    }
    
    public Card Draw(Hand receivingHand)
    {
        
        var cardToDraw = cardsInDeck[0];
        Remove(cardToDraw);
        //Encounter.playerHand.AddToHand(cardToDraw);
        Debug.Log("drew card");
        return receivingHand.Add(cardToDraw);
    }
    

    public Card Add(Card cardToAdd, int targetPosition = -1)
    {
        if (targetPosition == -1)
        {
            cardsInDeck.Add(cardToAdd);
            return cardToAdd;
        }
        cardsInDeck.Insert(targetPosition, cardToAdd);
        return cardToAdd;
    }

    public Card Remove(Card cardToRemove)
    {
        cardsInDeck.Remove(cardToRemove);
        return cardToRemove;
    }

    public void Shuffle()
    {
        List<Card> newList = new List<Card>();
        newList.AddRange(cardsInDeck);
        for (int i = 0; i <cardsInDeck.Count; i++)
        {
            int temporaryInt = (int)Mathf.Floor(Random.Range(0, newList.Count));
            cardsInDeck[i] = newList[temporaryInt];
            newList.RemoveAt(temporaryInt);
        }

    }


}
