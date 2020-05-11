using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public Hand handToDisplay;
    public CardGame currentGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Card card in handToDisplay.cardsInHand)
        {
            bool isAccountedFor = false;
            ClickableCard[] currentlyShown = gameObject.GetComponentsInChildren<ClickableCard>();
            for (int i = 0; i < currentlyShown.Length; i++)
            {
                if (currentlyShown[i].whichCardIsThis == card)
                {
                    isAccountedFor = true;
                }


                
            }
            if (!isAccountedFor)
            {
                GameObject newObject = new GameObject(card.displayedInfo.cardName, typeof(UnityEngine.UI.Image), typeof(ClickableCard));
                newObject.transform.SetParent(gameObject.transform);
                newObject.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
                newObject.GetComponent<UnityEngine.UI.Image>().sprite = card.displayedInfo.normalArt;
                newObject.GetComponent<ClickableCard>().currentGame = currentGame;
                newObject.GetComponent<ClickableCard>().thisObject = newObject;
                newObject.GetComponent<ClickableCard>().whichCardIsThis = card;
            }
            
        }
    }

    public void OnPointerDown()
    {

    }

}
