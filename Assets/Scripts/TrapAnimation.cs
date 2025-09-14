using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class TrapAnimation : MonoBehaviour
    {
    #region Private Variables

        [SerializeField]
        private float activeDuration = 3f;

     

    #endregion

        [SerializeField]
        private List<GameObject> targets = new List<GameObject>();

        private void Start()
        {
            Deactivate();
        }

        private void Deactivate()
        {
            targets.ForEach(go => go.SetActive(false));
            Invoke(nameof(Activate) , Random.Range(activeDuration , activeDuration + 4f));
        }

        private void Activate()
        {
            targets.ForEach(go => go.SetActive(true));
            Invoke(nameof(Deactivate) , Random.Range(4f , 7f));
        }

    #region Private Methods

    

    #endregion
    }
}