using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventManager
{

    private Dictionary<Type, CardGameEvent.Handler> _registeredHandlers = new Dictionary<Type, CardGameEvent.Handler>();

    public void Register<T>(CardGameEvent.Handler handler) where T : CardGameEvent
    {
        var type = typeof(T);
        if (_registeredHandlers.ContainsKey(type))
        {
            if (!IsEventHandlerRegistered(type, handler))
                _registeredHandlers[type] += handler;
        }
        else
        {
            _registeredHandlers.Add(type, handler);
        }
    }

    public void Unregister<T>(CardGameEvent.Handler handler) where T : CardGameEvent
    {
        var type = typeof(T);
        if (!_registeredHandlers.TryGetValue(type, out var handlers)) return;

        handlers -= handler;

        if (handlers == null)
        {
            _registeredHandlers.Remove(type);
        }
        else
        {
            _registeredHandlers[type] = handlers;
        }
    }

    public void Fire(CardGameEvent e)
    {
        var type = e.GetType();

        if (_registeredHandlers.TryGetValue(type, out var handlers))
        {
            handlers(e);
        }
    }

    public bool IsEventHandlerRegistered(Type typeIn, Delegate prospectiveHandler)
    {
        return _registeredHandlers[typeIn].GetInvocationList().Any(existingHandler => existingHandler == prospectiveHandler);
    }
}

public abstract class CardGameEvent
{
    public readonly float creationTime;

    public CardGameEvent()
    {
        creationTime = Time.time;
    }

    public delegate void Handler(CardGameEvent e);
}


//IMPORTANT
public class CardPlayed : CardGameEvent
{
    public Card cardPlayed;

    public CardPlayed(Card someCard)
    {
        this.cardPlayed = someCard;
    }
}

public class CardDrawn : CardGameEvent
{

}

//Event for NPC actions
public class NPCTakesAction : CardGameEvent
{
    public NPC npcThatActed;

    public NPCTakesAction(NPC currentNPC)
    {
        npcThatActed = currentNPC;
    }
}

public class CardDiscarded : CardGameEvent
{
    public Card cardDiscarded;

    public CardDiscarded(Card someCard)
    {
        this.cardDiscarded = someCard;
    }
}
