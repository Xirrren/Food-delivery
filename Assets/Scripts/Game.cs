using UnityEngine;
using UnityEngine.SceneManagement;

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
            Settlement.instance.ScoreSettlement();
            Invoke(nameof(GotoTitleScreen) , 3f);
        }

    #endregion

    #region Private Methods

        private void GotoTitleScreen()
        {
            SceneManager.LoadScene("TitleScene");
        }

    #endregion
    }
}