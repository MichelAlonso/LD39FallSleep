using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    public int energyMax = 200;
    public float energy = 100;
    public float energyPercent = .5f;
    public float drainRate = .1f;
    public Vector3 initialPosition = Vector3.zero;
    public List<MonoBehaviour> disableOnDie;

    public Action OnDie;

    //[SerializeField]
    //EnergyUI energyUI;
    private void Awake()
    {
        initialPosition = transform.position;
    }

    public void Hit(float amount)
    {
        amount = Mathf.Max(amount, 0);
        amount = Mathf.Min(amount, 2);
        energy += amount;
        energy = Mathf.Min(energy, energyMax);
    }

    private void Update()
    {
        if (energy <= 0)
        {
            Die();
            return;
        }

        energy -= drainRate;
        energy = Mathf.Max(energy, 0);
        energyPercent = energy / energyMax;
    }
    private void Die()
    {
        for (int i = 0; i < disableOnDie.Count; i++)
        {
            disableOnDie[i].enabled = false;
        }

        OnDie.Invoke(true);
    }


    public void Reset()
    {
        for (int i = 0; i < disableOnDie.Count; i++)
        {
            disableOnDie[i].enabled = true;
        }
        energy = 100;
        energyMax = 200;
        drainRate = .1f;

        transform.position = initialPosition;
    }
}
