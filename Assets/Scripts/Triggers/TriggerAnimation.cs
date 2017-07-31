using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour {
    [SerializeField]
    Animator animator;
    [SerializeField]
    string trigger;
    [SerializeField]
    private float delay;
    [SerializeField]
    bool disableAfter = true;
    [SerializeField]
    bool onStart = false;

    private void Start()
    {
        if (onStart)
        {
            StartCoroutine(Trigger(delay));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        StartCoroutine(Trigger(delay));
    }

    IEnumerator Trigger(float delay)
    {
        yield return new WaitForSeconds(delay);

        animator.SetTrigger(trigger);
        if (disableAfter)
        {
            enabled = !disableAfter;
            //gameObject.SetActive(!disableAfter);
        }
    }
}
