using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public interface IObserverable
{
    void RegisterObserver(IObserverable observer);
    void RemoveObserver(IObserverable observer);
    void Notify()
    {
        foreach(var observer in observerables)
    }
    
}
    