using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iris : Card
{
    public Iris()
    {
        displayedInfo.normalArt = Resources.Load<Sprite>("Golem game cards_Iris");
        displayedInfo.isPlayable = true;
        displayedInfo.cardName = "Iris";
    }

    public override void Effect()
    {
        Debug.Log("Played Iris");
    }
}
