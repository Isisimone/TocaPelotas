using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace TocaPelotas
{
    public class GameManager : MonoBehaviour
    {
        [Header("Animation")]
        [SerializeField, Min(0.5f)] float duration = 2f;
        [SerializeField] Ease ease = Ease.OutBounce;
        [Header("Managers")]
        [SerializeField] WorldManager worldManager;
        Ramp[] ramps;
        Vector3[] initialPositions;
        bool isFirstTime;

        void Awake()
        {
            Assert.IsNotNull(worldManager, "ERROR: falta worldManager");

            isFirstTime = true;
            ramps = FindObjectsByType<Ramp>(FindObjectsSortMode.None);
            initialPositions = new Vector3[ramps.Length];

            var cameraHeight = Camera.main.orthographicSize * 2;

            for (int i = 0; i < ramps.Length; i++)
            {
                // Guardo la posición inicial
                initialPositions[i] = ramps[i].transform.position;
                // Muevo la rampa
                ramps[i].transform.position += cameraHeight * Vector3.up;
            }
        }

        internal void PlayGame()
        {
            if (isFirstTime)
            {
                PlayAnimation();
                isFirstTime = false;
            }
            else
                worldManager.PlayGame();
        }

        void PlayAnimation()
        {
            for (int i = 0; i < ramps.Length; i++)
            {
                if (i == 0)
                    ramps[i].transform.DOMove(initialPositions[i], duration)
                        .SetEase(ease)
                        .OnComplete(OnCompleteCallback);
                else
                    ramps[i].transform
                        .DOMove(initialPositions[i], Random.Range(duration / 2, duration))
                        .SetEase(ease);
            }
        }

        void OnCompleteCallback()
        {
            worldManager.PlayGame();
        }
    }
}
