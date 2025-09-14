using UnityEngine;

namespace DefaultNamespace
{
    public class Trap : MonoBehaviour
    {
        [SerializeField]
        private float playerCanMoveTime = 2f;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.gameObject.TryGetComponent(out PlayerCharacter player)) return;
            player.DisableCanMove(playerCanMoveTime);
        }
    }
}