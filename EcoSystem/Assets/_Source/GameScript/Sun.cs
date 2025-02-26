using _Source.GameScript.Interfaces;
using UnityEngine;

namespace _Source.GameScript
{
    public class Sun : MonoBehaviour, IObserver
    {
        [SerializeField] private Transform centerPoint; // Центр вращения (пустой объект в центре сцены)
        [SerializeField] private float radius = 5f; // Радиус движения солнца

        private float _angle = -Mathf.PI / 2;
        private void Start()
        {
            DayNightCycleManager manager = FindObjectOfType<DayNightCycleManager>();
            if (manager != null)
            {
                manager.RegisterObserver(this);
            }
        }

        public void UpdateTime(float time)
        {
            _angle = -time * Mathf.PI * 2f - Mathf.PI / 2f;

            float x = centerPoint.position.x + Mathf.Cos(_angle) * radius;
            float y = centerPoint.position.y + Mathf.Sin(_angle) * radius;

            transform.position = new Vector3(x, y, transform.position.z);
        }
    }
}