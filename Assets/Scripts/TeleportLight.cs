using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Assertions;

namespace DefaultNamespace
{
    public class TeleportLight : MonoBehaviour
    {
        [SerializeField]
        private TeleportLight pairTeleportLight;

        [SerializeField]
        private ParticleSystem effectPrefab;

        
        private bool canTeleport;

        private void Start()
        {
            Assert.IsNotNull(pairTeleportLight , "pairTeleportLight is empty.");
            canTeleport = true;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (canTeleport ==false) return;
            if (!col.gameObject.TryGetComponent(out PlayerCharacter player)) return;
            player.StopDashing();
            DisableTeleport();
            pairTeleportLight.DisableTeleport();
            Invoke(nameof(DestroyPairTeleport) , 0.01f);
            Instantiate(effectPrefab , player.transform.position , quaternion.identity);
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

        public void SetPair(TeleportLight teleportLight)
        {
            pairTeleportLight = teleportLight;
        }
    }
}