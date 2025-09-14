using System;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class TitleScene : MonoBehaviour
    {
        [SerializeField]
        private Button enterGameButton;

        private void Start()
        {
         enterGameButton.onClick.AddListener(EnterGame);   
        }

        private void EnterGame()
        {
            SceneManager.LoadScene("GameScene");
            AudioMgr.Instance.PlaySFX(AudioMgr.SFXType.MenuBtn);
        }
    }
}