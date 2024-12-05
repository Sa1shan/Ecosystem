using _Source.GameScript.Interfaces;
using UnityEngine;

namespace _Source.GameScript
{
    public class Sky : MonoBehaviour, IObserver
    {
        private Timer _timer;
        private Sky _sky;
        private void Start()
        {
            _timer.RegisterObserver(_sky);
        }
        public void Update(float currentTime)
        {
            
        }
    }
}