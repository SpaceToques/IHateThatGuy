using UnityEngine;
using System.Collections.Generic;
using System;


/// <summary>
/// Class for adding listeners, and calling functions on all listeners
/// <see cref="Listener"/>
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Listenable<T> where T : Listener {
    List<T> listeners;

    public void AddListener(T listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(T listener)
    {
        listeners.Remove(listener);
    }

    public void ForEachListener(Action<T> f)
    {
        foreach (T listener in listeners)
        {
            f.Invoke(listener);
        }
    }
}
