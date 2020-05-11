using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class representing a singular instance of a card game, listing specific players and elements currently involved. Think of it as a collection of cards and players at a table.
/// </summary>
public class CardGame 
{
    public Player[] participants;
    public ICardGameElement[] elements;
    public FiniteStateMachine<CardGame> cardGameFSM;

    public Card Play(Card cardToPlay)
    {
        cardToPlay.Effect();
        return cardToPlay;
    }

    /// <summary>
    /// Finite State Machine and its states begin here
    /// </summary>
    #region
    public class BeginningOfTurn : FiniteStateMachine<CardGame>.State
    {
        public Player controllerOfTurn;
        public delegate void BeginningOfTurnEffects();
        public static BeginningOfTurnEffects whatHappensAtBeginningOfTurn;
        public override void OnEnter()
        {
            if (whatHappensAtBeginningOfTurn != null)
            {
                whatHappensAtBeginningOfTurn();

            }
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override void Update()
        {
            base.Update();
        }
    }

    public class MainTurn : FiniteStateMachine<CardGame>.State
    {
        public Player controllerOfTurn;
        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override void Update()
        {
            base.Update();
        }
    }

    public class EndTurn : FiniteStateMachine<CardGame>.State
    {
        public Player controllerOfTurn;
        public delegate void EndOfTurnEffects();
        public static EndOfTurnEffects whatHappensAtEndOfTurn;

        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnExit()
        {
            if (whatHappensAtEndOfTurn != null)
            {
                whatHappensAtEndOfTurn();
            }
        }

        public override void Update()
        {
            base.Update();
        }
    }

    public class WaitForInput : FiniteStateMachine<CardGame>.State
    {
        public delegate void CheckingForInput();
        public static CheckingForInput whatAmIWaitingFor;
        public override void OnEnter()
        {

        }

        public override void OnExit()
        {

        }

        public override void Update()
        {
            if (whatAmIWaitingFor != null)
            {
                whatAmIWaitingFor();

            }
        }
    }
    #endregion
}
