using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public abstract class BaseHitReceiver : MonoBehaviour
{
    public abstract void ReceiveHit();
}
