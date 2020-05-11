using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : Player
{

    public NPC(string newName)
    {
        name = newName;
    }


    public Sprite npcSprite;
    public Card selectedCard;
    public string successMessage;
    public string failureMessage;
    public int turnsExpired;
    public string description;

    public delegate bool Conditions();
    public Conditions victoryCondition;

    public abstract void Effect();


}
