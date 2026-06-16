using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace TocaPelotas
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] UIManager uIManager;
        int score;
        int highscore;

        void Awake()
        {
            Assert.IsNotNull(uIManager, "ERROR: falta uIManager");

            Reset();
        }

        public void AddScore(int score)
        {
            this.score += score;
            uIManager.UpdateScore(this.score);
        }

        internal void Reset()
        {
            score = 0;
            uIManager.UpdateScore(score);
            highscore = PlayerPrefs.GetInt(Constants.HIGHSCORE_KEY, 0);
            uIManager.UpdateHighscore(highscore);
        }

        internal void UpdateHighscore()
        {
            if (score > highscore)
            {
                highscore = score;
                uIManager.UpdateHighscore(highscore);
                PlayerPrefs.SetInt(Constants.HIGHSCORE_KEY, highscore);
                PlayerPrefs.Save();
            }
        }
    }
}
