using System;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace TocaPelotas
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] TMP_Text scoreTMP_Text;
        [SerializeField] TMP_Text highscoreTMP_Text;

        void Awake()
        {
            Assert.IsNotNull(scoreTMP_Text, "ERROR: falta score");
            Assert.IsNotNull(highscoreTMP_Text, "ERROR: falta highscore");
        }

        public void UpdateScore(int score)
        {
            scoreTMP_Text.text = $"Score: {score}";
        }
    }
}
