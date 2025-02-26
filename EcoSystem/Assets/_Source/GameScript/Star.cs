using System.Collections.Generic;
using _Source.GameScript.Interfaces;
using UnityEngine;

namespace _Source.GameScript
{
    public class Star : MonoBehaviour, IObserver
    {
        [SerializeField] private List<SpriteRenderer> stars;
        [SerializeField] private float fadeSpeed = 1f;

        private float _targetAlpha = 0f;
        private MaterialPropertyBlock _materialPropertyBlock;

        private void Start()
        {
            _materialPropertyBlock = new MaterialPropertyBlock(); // Инициализируем MaterialPropertyBlock
            SetStarsAlpha(0f); // Изначально скрываем звезды
        }

        public void UpdateTime(float time)
        {
            if (time >= 0f && time < 0.25f) // Ночь
            {
                _targetAlpha = 1f; // Звезды полностью видны
            }
            else if (time >= 0.25f && time < 0.5f) // Утро
            {
                _targetAlpha = 0f; // Звезды скрыты
            }
            else if (time >= 0.5f && time < 0.75f) // День
            {
                _targetAlpha = 0f; // Звезды скрыты
            }
            else if (time >= 0.75f && time <= 1f) // Вечер
            {
                _targetAlpha = Mathf.Lerp(0f, 1f, (time - 0.75f) * 4f); // Звезды начинают появляться
            }

            StopAllCoroutines();
            StartCoroutine(FadeStars());
        }

        private System.Collections.IEnumerator FadeStars()
        {
            float currentAlpha = stars[0].color.a;

            // Плавно изменяем альфа-значение звезд
            while (!Mathf.Approximately(currentAlpha, _targetAlpha))
            {
                currentAlpha = Mathf.MoveTowards(currentAlpha, _targetAlpha, fadeSpeed * Time.deltaTime);
                SetStarsAlpha(currentAlpha);
                yield return null;
            }
        }

        private void SetStarsAlpha(float alpha)
        {
            foreach (var star in stars)
            {
                // Получаем материал через MaterialPropertyBlock
                star.GetPropertyBlock(_materialPropertyBlock);

                // Меняем альфа-канал в _Color
                _materialPropertyBlock.SetColor("_Color", new Color(star.color.r, star.color.g, star.color.b, alpha));

                // Применяем изменения к звезде
                star.SetPropertyBlock(_materialPropertyBlock);
            }
        }
    }
}