using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Deck", order = 1)]
public class Deck : ScriptableObject, ICardGameElement
{
    
    public List<Card> cardsInDeck;
    public string[] namesOfCards;

    public Deck()
    {
        cardsInDeck = new List<Card>();
        Shuffle();
    }

    public Card Draw(Hand receivingHand)
    {
        if (cardsInDeck.Count > 0)
        { 

            var cardToDraw = cardsInDeck[0];
            Remove(cardToDraw);
            //Encounter.playerHand.AddToHand(cardToDraw);
            Debug.Log("drew card");
            return receivingHand.Add(cardToDraw);
        }

        return null;
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
#if UNITY_EDITOR
[CustomEditor(typeof(Deck)), CanEditMultipleObjects]
public class DeckEditor : Editor
{
    SerializedProperty m_namesOfCards;
    
    private void OnEnable()
    {
        m_namesOfCards = serializedObject.FindProperty("namesOfCards");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(m_namesOfCards, new GUIContent("Cards in Deck"));
        serializedObject.ApplyModifiedProperties();
    }
}
#endif