using UnityEngine;

namespace DefaultNamespace
{
    public class Game : MonoBehaviour
    {
    #region Private Variables

        private bool gameOver;

    #endregion

    #region Public Methods

        public void GameOver()
        {
            if (gameOver) return;
            gameOver = true;
            Debug.Log($"GameOver");
        }

    #endregion
    }
}