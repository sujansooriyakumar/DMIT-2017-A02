using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class Sightline : MonoBehaviour
{
    public float radius = 1.0f;
    public LayerMask hitLayers;
   // public event Action<Vector3> OnPlayerSeen;
    void Update()
    {
        CustomDebug.DrawDebugCircle(transform.position, radius, Color.red, 50);
    }

    public bool SightlineCheck()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject.CompareTag("Player"))
            {
               // OnPlayerSeen?.Invoke(hit.gameObject.transform.position);
                return true;
            }
        }

        return false;
    }

   
}
