using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using Assets.Code.Components.Guns;
using UnityEngine.UI;
using System;

public class HitInfoCollector : MonoBehaviour
{
    private Text textDisplay;

    void Start()
    {
        var root = this.GetComponentInParent<Root>();
        if (root != null) textDisplay = root.GetComponentInChildren<Text>();
    }

    public void CollectHit()
    {
        if (textDisplay != null)
        {
            IncrementHitCounter();
        }
    }

    private void IncrementHitCounter()
    {
        int hitCounter = int.Parse(textDisplay.text);
        textDisplay.text = (++hitCounter).ToString();
    }

    public void Reset()
    {
        textDisplay.text = "0";
    }
}
