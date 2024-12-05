using System.Collections.Generic;
using _Source.GameScript.Interfaces;
using UnityEngine;

namespace _Source.GameScript
{
    public class Timer : MonoBehaviour, IObserverable
    {
        public List<IObserver> observerables = new List<IObserver>();
        private float currentTime = 0f;

        public void RegisterObserver(IObserver observer)
        {
            observerables.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observerables.Remove(observer);
        }

        public void Notify()
        {
            foreach (IObserver observer in observerables)
            {
                observer.Update(currentTime);
            }
        }

        private void Update()
        {
            currentTime += Time.deltaTime;
            Notify();
        }
    }
}
