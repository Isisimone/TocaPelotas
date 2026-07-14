using System;
using UnityEngine;

namespace TocaPelotas
{
    [RequireComponent(typeof(AudioSource), typeof(Collider2D))]
    public class Background : MonoBehaviour
    {
        AudioSource audioSource;

        internal void SetActive(bool value)
        {
            enabled = value;
        }

        void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            enabled = false;
        }

        void OnMouseDown()
        {
            if (enabled)
                audioSource.Play();
        }
    }
}
