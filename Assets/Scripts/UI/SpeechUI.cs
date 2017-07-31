using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechUI : MonoBehaviour {
    [SerializeField]
    GameObject textPanel;
    [SerializeField]
    Text textField;
    string fullSpeech;
    string speech;
    int index;
    
    public float delay;

    Coroutine coroutine;
    public Action OnComplete;

    bool isRunning = false;

    private void Start()
    {
        SetText("You're running out of energy. Stay in the lights to stay awake.");
    }

    public void SetText(string text)
    {
        textField.text = "";
        fullSpeech = text;
        coroutine = StartCoroutine(Speech());
    }

    public void Complete()
    {
        if (isRunning)
        {
            StopCoroutine(coroutine);
        }
    }

    IEnumerator Speech()
    {
        isRunning = true;
        yield return new WaitForSeconds(delay);

        speech += fullSpeech[index];
        textField.text = speech;
        index++;

        if (index < fullSpeech.Length)
        {
            coroutine = StartCoroutine(Speech());
        } else
        {
            if (OnComplete != null)
            {
                OnComplete();
            }
            index = 0;
            isRunning = false;
        }
    }
}
