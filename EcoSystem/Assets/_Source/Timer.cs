using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour, IObserverable
{
    public List<IObserverable> observerables = new List<IObserverable>();

    private float currentTime = 0f;
    public void Notify()
    {
        foreach (var observer in observerables)
        {
            
        }
    }

    private void Update(float deltaTime)
    {
        currentTime += Time.deltaTime;
        Notify();
    }

    public void RegisterObserver(IObserverable observer)
    {
        observerables.Add(observer);
    }

    public void RemoveObserver(IObserverable observer)
    {
        observerables.Remove(observer);
    }
}
