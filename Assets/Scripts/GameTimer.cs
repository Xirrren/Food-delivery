using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameTimer : MonoBehaviour
    {
    #region Private Variables

        private float playTime;

        [SerializeField]
        [Min(1)]
        private float defaultPlayTime = 60f;

        [SerializeField]
        private TMP_Text gameTimeText;

    #endregion

    #region Unity events

        private void Start()
        {
            playTime = defaultPlayTime;
        }

        [SerializeField]
        private Game game;

        private void Update()
        {
            playTime -= Time.deltaTime;
            gameTimeText.SetText(Math.Max(0 , playTime).ToString("F1"));
            if (playTime <= 0) game.GameOver();
        }

    #endregion
    }
}