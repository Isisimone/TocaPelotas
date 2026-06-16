using System;
using UnityEngine;
using UnityEngine.Assertions;
// using UnityEngine.Assertions;

namespace TocaPelotas
{
    [RequireComponent(typeof(Collider2D))]
    public class Alien : MonoBehaviour
    {
        [SerializeField, Min(1)] int score = 20;
        [SerializeField] GameObject destructionPrefab;
        // Declarar el evento OnAlienDestroyedEvent
        public event Action<Alien> OnAlienDestroyedEvent;

        void Awake()
        {
            Assert.IsNotNull(destructionPrefab, "ERROR: falta prefab");
        }

        internal int GetScore()
        {
            return score;
        }

        void OnMouseDown()
        {
            // Lanzar el evento, informar de que 
            //      ha ocurrido el evento OnAlienDestroyedEvent
            // if (OnAlienDestroyedEvent != null)
            //     OnAlienDestroyedEvent.Invoke(this);
            // Equivale a
            OnAlienDestroyedEvent?.Invoke(this);
        }

        internal void Destroy()
        {
            Instantiate(destructionPrefab, transform.position, transform.rotation);
        }
    }
}
