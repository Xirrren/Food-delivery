using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerCharacterController : MonoBehaviour
    {
        private PlayerCharacter[] players;

        public static PlayerCharacterController Instance;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            players = FindObjectsOfType<PlayerCharacter>();
        }

        public void ClearFood()
        {
            foreach (var playerCharacter in players)
            {
                playerCharacter.HideFood();
            }
        }
    }
}