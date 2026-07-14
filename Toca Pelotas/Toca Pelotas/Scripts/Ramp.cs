using UnityEngine;

namespace TocaPelotas
{
    [RequireComponent(typeof(AudioSource), typeof(Collider2D))]
    public class Ramp : MonoBehaviour
    {
        AudioSource audioSource;

        void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(Constants.ALIEN_TAG))
                audioSource.Play();
        }
    }
}
