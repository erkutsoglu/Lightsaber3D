using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightsaber : MonoBehaviour
{
    [HideInInspector]
    public GameObject hitParticle;

    [Header("Settings")]
    public bool executeHitParticle;

    public void HitParticleExecuter()
    {
        if (executeHitParticle)
        {
            hitParticle.transform.SetParent(transform.root);
            hitParticle.SetActive(true);
        }
    }
}
