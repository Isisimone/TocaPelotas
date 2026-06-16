using System;
using UnityEngine;

namespace TocaPelotas
{
    [RequireComponent(typeof(PolygonCollider2D))]
    public class Spikes : MonoBehaviour
    {
        public event Action OnGameOverEvent;

        void OnCollisionEnter2D(Collision2D collision)
        {
            // Lanzar el evento OnGameOverEvent
            OnGameOverEvent?.Invoke();
        }
    }
}
