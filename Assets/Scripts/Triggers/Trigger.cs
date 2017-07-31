using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class Trigger : MonoBehaviour {
    enum TriggerType
    {
        EnableObject,
        PlaySound,
        Action
    }
    [SerializeField]
    TriggerType type;
    [SerializeField]
    new AudioSource audio;
    [SerializeField]
    GameObject target;
    [SerializeField]
    bool turnOn = true;

    [SerializeField]
    List<UnityAction> actions = new List<UnityAction>();
    [SerializeField]
    UnityEvent action;
    [SerializeField]
    float delay;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        StartCoroutine(TriggerAction(delay));

    }

    IEnumerator TriggerAction(float delay)
    {
        yield return new WaitForSeconds(delay);

        switch (type)
        {
            case TriggerType.EnableObject:
                target.SetActive(turnOn);
                break;
            case TriggerType.PlaySound:
                audio.Play();
                break;
            case TriggerType.Action:
                for (int i = 0; i < actions.Count; i++)
                {
                    if (actions[i] != null)
                    {
                        actions[i]();
                    }
                }
                Debug.Log(action);
                if (action != null)
                {
                    action.Invoke();
                }
                break;
        }
    }
}
