using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using Assets.Code.Components.Guns;
using UnityEngine.UI;

public class HitInfoCollector : MonoBehaviour
{
    public void CollectHit()
    {
        //var root = GameObject.FindGameObjectWithTag("Canvas").GetComponentInChildren<Text>().gameObject;
        var text = this.GetComponentInParent<Root>().GetComponentInChildren<Text>();
        if (text != null)
        {
            //ExecuteEvents.ExecuteHierarchy<IHitEventHandler>(root, null, (x, y) => x.Hit());

            int hitCounter = int.Parse(text.text);
            text.text = (++hitCounter).ToString();
        }
    }
}
