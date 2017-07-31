using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainZone : MonoBehaviour {

    public float damage = -4f;

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        Player player = other.GetComponent<Player>();
        player.Hit(damage);
    }
}
