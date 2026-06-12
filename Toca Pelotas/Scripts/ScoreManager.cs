using UnityEngine;
using UnityEngine.Assertions;

namespace TocaPelotas
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] UIManager uIManager;
        int score;

        void Awake()
        {
            Assert.IsNotNull(uIManager, "ERROR: falta uIManager");

            score = 0;
        }

        public void AddScore(int score)
        {
            this.score += score;
            uIManager.UpdateScore(this.score);
        }
    }
}
