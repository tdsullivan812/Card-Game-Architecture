using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class Setup : MonoBehaviour
{
    public string[] Players;
    public Deck[] listOfDecks;
    // Start is called before the first frame update
    void Start()
    {
        CardGame currentGame = new CardGame();

        currentGame.elements = new ICardGameElement[listOfDecks.Length];
        for (int i = 0; i < listOfDecks.Length; i++)
        {
            //listOfDecks[i] = new Deck();
            for (int j = 0; j < listOfDecks[i].namesOfCards.Length; j++)
            {
                Card newCard;
                System.Type cardType = System.Type.GetType(listOfDecks[i].namesOfCards[j]);
                newCard = (Card)cardType.GetConstructor(System.Type.EmptyTypes).Invoke(null);
                listOfDecks[i].Add(newCard);
            }
            listOfDecks[i].Shuffle();
            currentGame.elements[i] = listOfDecks[i];
        }

        currentGame.participants = new Player[Players.Length];
        for (int i = 0; i < Players.Length; i++)
        {
            currentGame.participants[i] = new Player(Players[i]);
            GameObject playerGameObject = new GameObject(currentGame.participants[i].name);
            playerGameObject.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            playerGameObject.transform.SetParent(GameObject.Find("Canvas").transform);

            playerGameObject.AddComponent<HandManager>().currentGame = currentGame;
            playerGameObject.GetComponent<HandManager>().handToDisplay = currentGame.participants[i].playerHand;
            Deck deckToDrawFrom = (Deck)currentGame.elements[0];
            deckToDrawFrom.Draw(currentGame.participants[i].playerHand);
        }

        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
/*
#if UNITY_EDITOR
[CustomEditor(typeof(Setup)), CanEditMultipleObjects]
public class SetupEditor : Editor
{
    SerializedProperty m_decks;


    private void OnEnable()
    {
        m_decks = serializedObject.FindProperty("listOfDecks");
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var myTarget = (Setup)target;
        EditorGUILayout.PropertyField(m_decks, new GUIContent("Decks"));

        serializedObject.ApplyModifiedProperties();
        

    }
}
#endif */