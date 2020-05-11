using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// An interface for collections of cards that behave as an entity in a card game. By default, Deck, Hand, and Discard implement this class. 
/// </summary>
public interface ICardGameElement
{
    Card Add(Card cardToAdd, int index);
    Card Remove(Card cardToRemove);
	
}
