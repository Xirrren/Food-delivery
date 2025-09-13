using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Trap : MonoBehaviour
    {
    #region Private Variables

        [SerializeField]
        private float playerCanMoveTime = 2f;

    #endregion

    #region Private Methods

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.TryGetComponent(out PlayerCharacter player)) return;
            player.DisableCanMove(playerCanMoveTime);
        }

    #endregion
    }
}