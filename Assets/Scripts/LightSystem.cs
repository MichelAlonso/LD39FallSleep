using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightSystem : MonoBehaviour {

    public List<SpotLightCollider> lights;

    public Action<float> OnHit;

    private void Awake()
    {
        lights = FindObjectsOfType<SpotLightCollider>().ToList();
    }

    private void Start()
    {
        for (int i = 0; i < lights.Count; i++)
        {
            lights[i].OnHit = Hit;
        }
    }

    private void Hit(SpotLightCollider light, float amount)
    {
        OnHit.Invoke(amount, true);
    }
}
