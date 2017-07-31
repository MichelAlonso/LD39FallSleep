using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnergyUI : MonoBehaviour {

    public RectTransform energyUI;
    float energy = 1f;

    private void Start()
    {
        Set(energy);
    }

    public void Set(float energy)
    {
        this.energy = Mathf.Max(0, energy);
        energyUI.localScale = new Vector3(energy, 1, 1);
    }
}
