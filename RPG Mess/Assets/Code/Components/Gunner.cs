using UnityEngine;
using System.Collections;
using Assets.Code.Common;
using System;
using Assets.Code.Components.Guns;

namespace Assets.Code.Components
{
    [RequireComponent(typeof(Animator))]
    public class Gunner : MonoBehaviour
    {
        [SerializeField]
        private BaseGun gun;

        // private variables
        private Animator animator;

        void Awake()
        {
            animator = this.GetComponent<Animator>();
        }

        // Use this for initialization
        void Start()
        {
            gun = UnityEngine.Object.Instantiate(
                gun,
                Vector3.zero,
                Quaternion.identity) as BaseGun;

            gun.transform.SetParent(this.transform);
        }
    }
}