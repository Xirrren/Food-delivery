using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TeleportLight : MonoBehaviour
    {
        [SerializeField]
        private TeleportLight pairTeleportLight;

        private bool canTeleport;

        private void Start()
        {
            canTeleport = true;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (canTeleport ==false) return;
            if (!col.gameObject.TryGetComponent(out PlayerCharacter player)) return;
            player.StopDashing();
            DisableTeleport();
            pairTeleportLight.DisableTeleport();
            Invoke(nameof(DestroyPairTeleport) , 0.25f);
            player.transform.position = pairTeleportLight.transform.position;
        }

        private void DestroyPairTeleport()
        {
            Destroy(pairTeleportLight.gameObject);
            Destroy(gameObject);
        }

        private void DisableTeleport()
        {
            canTeleport = false;
        }
    }
}