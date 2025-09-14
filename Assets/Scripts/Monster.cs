using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Monster : MonoBehaviour
    {
        [SerializeField]
        private List<RuntimeAnimatorController> animators;

        [SerializeField]
        private Animator animator;

        private void Start()
        {
            animator.runtimeAnimatorController = animators[Random.Range(0 , animators.Count)];
        }
    }
}