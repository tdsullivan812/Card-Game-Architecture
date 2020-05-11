using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
/// <summary>
/// The base class for all cards and 
/// </summary>
public abstract class Card
{
    
    //Data Structures
    #region
        /// <summary>
        /// A struct for containing all of a card's basic information. Add to this if you want cards to have more attributes, e.g. Victory Points, activation cost, etc.
        /// </summary>
    public struct CardInfo
    {
        public string cardName;
        public Suit suit;
        public int value;
        public bool isPlayable;
        public string text;
        public Sprite normalArt;
        public Sprite hoverArt;

    }


    public enum Suit : byte
    {
        Club,
        Diamond,
        Heart,
        Spade,
        Undefined
    }
    #endregion


    //public GameObject cardGameObject;
    public CardInfo displayedInfo;

    /// <summary>
    /// Can be overridden in a subclass to give the card a unique effect when played.
    /// </summary>
    public abstract void Effect();

    public Card()
    {
        //InitializeCardGameObject();
    }

    /*
    public void InitializeCardGameObject()
    {
        if (Encounter.objectPools.ContainsKey(displayedInfo.cardName) == false)
        {
            cardGameObject = Object.Instantiate(Resources.Load<GameObject>("Cards/Basic Card"));
            Encounter.objectPools.Add(this.displayedInfo.cardName, new ObjectPool(cardGameObject));

            //cardGameObject.GetComponentsInChildren<TextMeshProUGUI>()[0].text = displayedInfo.cardName;
            TextMeshProUGUI textMesh = cardGameObject.GetComponentsInChildren<TextMeshProUGUI>(true)[1];
            textMesh.text = displayedInfo.text;
            textMesh.color = ChooseColor(displayedInfo.type);
            //cardGameObject.GetComponentsInChildren<TextMeshProUGUI>(true)[1].text = displayedInfo.text;
            //cardGameObject.GetComponentsInChildren<TextMeshProUGUI>(true)[1].outlineColor = ChooseColor(displayedInfo.type);

            var cardImages = cardGameObject.GetComponentsInChildren<UnityEngine.UI.Image>();
            //UnityEngine.UI.Image cardBackgroundImage = cardGameObject.GetComponent<UnityEngine.UI.Image>();
            //UnityEngine.UI.Image hoverImage = cardGameObject.GetComponentInChildren<UnityEngine.UI.Image>();
            cardGameObject.name = displayedInfo.cardName;
            cardImages[0].sprite = displayedInfo.normalArt;
            cardImages[1].sprite = displayedInfo.hoverArt;

            
            switch (displayedInfo.type)
            {
                case Card.Vibes.Calm:
                    cardBackgroundImage.sprite = Resources.Load<Sprite>("Cards/Bubbly_Background");
                    break;
                case Card.Vibes.Bubbly:
                    cardBackgroundImage.sprite = Resources.Load<Sprite>("Cards/Calm_Background");
                    break;
                case Card.Vibes.Hype:
                    cardBackgroundImage.sprite = Resources.Load<Sprite>("Cards/Hype_Background");
                    break;
                default:
                    break;

            }
            
            cardGameObject.AddComponent<CardIdentifier>().whichCardIsThis = this;
            Encounter.objectPools[this.displayedInfo.cardName].Push(cardGameObject);
            //InputManager.activeCardGameObjects.Add(cardGameObject);
        }
    }*/

}
