using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string name;
    public Hand playerHand;
    
    public Player(string newName = "New Player")
    {
        name = newName;
        playerHand = new Hand();
    }


}
