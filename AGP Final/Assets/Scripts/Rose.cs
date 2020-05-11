using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rose : Card
{
    public Rose()
    {
        displayedInfo.normalArt = Resources.Load<Sprite>("Golem game cards_Rose");
        displayedInfo.isPlayable = true;
        displayedInfo.cardName = "Rose";
    }

    public override void Effect()
    {
        Debug.Log("Played Rose");
    }
}
