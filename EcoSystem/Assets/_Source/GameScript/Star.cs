using System;
using _Source.GameScript.Interfaces;
using UnityEngine;

namespace _Source.GameScript
{
    public class Star : MonoBehaviour, IObserver
    {
        private Timer _timer;
        private Star _star;
        private void Start()
        {
            _timer.RegisterObserver(_star);
        }
        public void Update(float currentTime)
        {
            throw new Exception();
        }
    }
}