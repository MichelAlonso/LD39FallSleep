using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour {
    public GameObject player;
    public Camera camera;
    public List<GameObject> objects;

	void Start () {
        player.SetActive(false);
	}

	public void Play()
    {
        camera.gameObject.SetActive(false);
        player.SetActive(true);
        gameObject.SetActive(false);

        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].SetActive(true);
        }
    }
}
