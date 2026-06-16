using System;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace TocaPelotas
{
    public class UIManager : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] Button playButton;
        [SerializeField] Button quitButton;
        [Header("Texts")]
        [SerializeField] TMP_Text scoreTMP_Text;
        [SerializeField] TMP_Text highscoreTMP_Text;
        [Header("Managers")]
        [SerializeField] WorldManager worldManager;

        void Awake()
        {
            Assert.IsNotNull(scoreTMP_Text, "ERROR: falta score");
            Assert.IsNotNull(highscoreTMP_Text, "ERROR: falta highscore");
            Assert.IsNotNull(playButton, "ERROR: falta playButton");
            Assert.IsNotNull(quitButton, "ERROR: falta quitButton");
            Assert.IsNotNull(worldManager, "ERROR: falta worldManager");

            playButton.onClick.AddListener(PlayGame);
            quitButton.onClick.AddListener(QuitGame);
        }

        void QuitGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit(0);
#endif
        }

        void PlayGame()
        {
            playButton.gameObject.SetActive(false);
            quitButton.gameObject.SetActive(false);
            worldManager.PlayGame();
        }

        public void UpdateScore(int score)
        {
            scoreTMP_Text.text = $"Score: {score}";
        }

        internal void ShowMenu()
        {
            playButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
        }

        internal void UpdateHighscore(int highscore)
        {
            highscoreTMP_Text.text = $"Highscore: {highscore}";
        }
    }
}
