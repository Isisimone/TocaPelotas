using UnityEngine;

namespace TocaPelotas
{
    [RequireComponent(typeof(AudioSource), typeof(ParticleSystem))]
    public class AlienDestruction : MonoBehaviour
    {
        AudioSource audioSource;
        new ParticleSystem particleSystem;

        void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            particleSystem = GetComponent<ParticleSystem>();

            var audioDuration = audioSource.clip.length;
            var particleDuration = particleSystem.main.duration + particleSystem.main.startLifetime.constantMax;
            var duration = Mathf.Max(audioDuration, particleDuration);

            Destroy(gameObject, duration);
        }
    }
}
