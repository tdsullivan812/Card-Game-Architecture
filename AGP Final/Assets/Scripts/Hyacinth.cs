using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyacinth : Card
{
    public Hyacinth()
    {
        displayedInfo.normalArt = Resources.Load<Sprite>("Golem game cards_Hyacinth");
        displayedInfo.isPlayable = true;
        displayedInfo.cardName = "Hyacinth";
    }
    public override void Effect()
    {
        Debug.Log("Played a Hyacinth");
    }
}
