using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace TocaPelotas
{
    public class WorldManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] Alien[] alienPrefabs;
        [SerializeField] Spikes spikes;
        [SerializeField] Background background;
        [Header("Progression Difficulty")]
        [SerializeField, Range(1f, 5f), Tooltip("Tiempo minimo para generar un nuevo alien")] float minTimeBetweenAliens = 1f;
        [SerializeField, Range(1f, 5f)] float maxTimeBetweenAliens = 3f;
        [SerializeField, Min(1)] int maxNumberOfAliens = 7;
        [SerializeField, Min(1)] int numberOfDestroyedAliensPerNewAlien = 5;
        [SerializeField, Range(0, 1f)] float timeMultiplier = 0.9f;
        [Header("Managers")]
        [SerializeField] ScoreManager scoreManager;
        [SerializeField] UIManager uIManager;
        List<Alien> aliens;
        bool isCoroutineActive;
        int destroyedAliens;
        float currentMinTimeBetweenAliens;
        float currentMaxTimeBetweenAliens;
        float currentMaxNumberOfAliens;

        // Al reiniciar partida debemos reiniciar también los
        //      valores de Progression Difficulty y el score

        void Awake()
        {
            Assert.IsTrue(alienPrefabs.Length > 0, "ERROR: faltan aliens");
            Assert.IsNotNull(scoreManager, "ERROR: falta scoreManager");
            Assert.IsNotNull(uIManager, "ERROR: falta uIManager");
            Assert.IsTrue(minTimeBetweenAliens <= maxTimeBetweenAliens, "ERROR: tiempos no válidos");
            Assert.IsNotNull(spikes, "ERROR: faltan spikes");
            Assert.IsNotNull(background, "ERROR: faltan background");

            aliens = new List<Alien>();
        }

        internal void PlayGame()
        {
            spikes.OnGameOverEvent += OnGameOverCallback;
            destroyedAliens = 0;
            scoreManager.Reset();
            currentMaxNumberOfAliens = maxNumberOfAliens;
            currentMaxTimeBetweenAliens = maxTimeBetweenAliens;
            currentMinTimeBetweenAliens = minTimeBetweenAliens;
            StartCoroutine(CreateAlienCoroutine());

            background.SetActive(true);
        }

        void OnGameOverCallback()
        {
            background.SetActive(false);
            spikes.OnGameOverEvent -= OnGameOverCallback;

            foreach (var alien in aliens)
            {
                alien.Destroy();
            }
            foreach (var alien in aliens)
            {
                Destroy(alien.gameObject);
            }
            aliens.Clear();

            StopAllCoroutines();
            uIManager.ShowMenu();
            scoreManager.UpdateHighscore();
        }

        IEnumerator CreateAlienCoroutine()
        {
            isCoroutineActive = true;
            // elegir espera aleatoria
            var randomDelay = Random.Range(currentMinTimeBetweenAliens, currentMaxTimeBetweenAliens);
            yield return new WaitForSeconds(randomDelay);

            if (aliens.Count < currentMaxNumberOfAliens)
            {
                CreateAlien();
                StartCoroutine(CreateAlienCoroutine());
            }
            else
                isCoroutineActive = false;
        }

        void CreateAlien()
        {
            // elegir posición aleatoria
            float posY = Camera.main.transform.position.y + Camera.main.orthographicSize * Constants.VERTICAL_FACTOR;
            float posX = Random.Range(
                -Camera.main.orthographicSize * Camera.main.aspect * Constants.HORIZONTAL_FACTOR,
                Camera.main.orthographicSize * Camera.main.aspect * Constants.HORIZONTAL_FACTOR);

            // elija aleatoriamente 1 al azar
            var randomIndex = Random.Range(0, alienPrefabs.Length);
            var alien = Instantiate(alienPrefabs[randomIndex]);
            alien.transform.position = new Vector3(posX, posY, 0);
            // Me suscribo al evento OnAlienDestroyedEvent
            alien.OnAlienDestroyedEvent += OnAlienDestroyedCallback;

            // Actualizo la lista
            aliens.Add(alien);
        }

        void OnAlienDestroyedCallback(Alien alien)
        {
            // Me desuscribo del evento
            alien.OnAlienDestroyedEvent -= OnAlienDestroyedCallback;
            // Sumo puntos
            scoreManager.AddScore(alien.GetScore());
            // Actualizo la lista
            aliens.Remove(alien);
            // Decir al alien que se destruya visualmente y audio
            alien.Destroy();
            // Destruyo el GO
            Destroy(alien.gameObject);
            // ¿Inicio otra corrutina?
            if (!isCoroutineActive)
                StartCoroutine(CreateAlienCoroutine());

            destroyedAliens++;
            // Cada 5 aliens destruidos pueda generarse uno más
            if (destroyedAliens % numberOfDestroyedAliensPerNewAlien == 0)
            {
                currentMaxNumberOfAliens++;
                //      cambiar los tiempos de creación
                currentMaxTimeBetweenAliens = currentMaxTimeBetweenAliens * timeMultiplier;
                currentMinTimeBetweenAliens *= timeMultiplier;
            }
        }
    }
}
