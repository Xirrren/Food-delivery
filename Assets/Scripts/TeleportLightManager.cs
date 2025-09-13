using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class TeleportLightManager : MonoBehaviour
    {
        [SerializeField]
        private TeleportLight teleportLightPrefab;

        [SerializeField]
        private List<Transform> teleportPositions1;

        [SerializeField]
        private List<Transform> teleportPositions2;

        // [SerializeField]
        private List<TeleportLight> spawnedTeleportLights = new List<TeleportLight>();

        private void Start()
        {
            InvokeRepeating(nameof(SpawnTeleportLight) , Random.Range(3f , 5f) , Random.Range(3f , 5f));
        }

        private void SpawnTeleportLight()
        {
            for (var i = spawnedTeleportLights.Count - 1 ; i >= 0 ; i--)
            {
                var spawnedTeleportLight = spawnedTeleportLights[i];
                if (spawnedTeleportLight != null)
                {
                    Destroy(spawnedTeleportLight.gameObject);
                }
                spawnedTeleportLights.RemoveAt(i);
            }

            var t1Pos          = teleportPositions1[Random.Range(0 , teleportPositions1.Count)];
            var t2Pos          = teleportPositions2[Random.Range(0 , teleportPositions2.Count)];
            var teleportLight1 = Instantiate(teleportLightPrefab);
            teleportLight1.transform.position = t1Pos.position;
            var teleportLight2 = Instantiate(teleportLightPrefab);
            teleportLight2.transform.position = t2Pos.position;
            spawnedTeleportLights.Add(teleportLight1);
            spawnedTeleportLights.Add(teleportLight2);
            teleportLight1.SetPair(teleportLight2);
            teleportLight2.SetPair(teleportLight1);
        }
    }
}