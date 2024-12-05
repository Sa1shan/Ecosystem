using _Source.GameScript.Interfaces;
using UnityEngine;

namespace _Source.GameScript
{
    public class Sun : MonoBehaviour, IObserver
    {
        private Timer _timer;
        private Sun _sun;
        private void Start()
        {
            _timer.RegisterObserver(_sun);
        }
        public void Update(float currentTime)
        {
            
        }
    }
}