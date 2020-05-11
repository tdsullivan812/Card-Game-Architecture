using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableCard : MonoBehaviour, UnityEngine.EventSystems.IPointerDownHandler
{
    public Card whichCardIsThis;
    public CardGame currentGame;
    public GameObject thisObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(UnityEngine.EventSystems.PointerEventData pointerEvent)
    {
        transform.parent.gameObject.GetComponent<HandManager>().handToDisplay.PlayFromHand(whichCardIsThis, currentGame);
    }
}
