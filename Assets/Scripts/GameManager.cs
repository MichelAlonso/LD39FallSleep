using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField]
    Player player;
    [SerializeField]
    UIManager managerUI;
    [SerializeField]
    LightSystem lightSystem;
    [SerializeField]
    CameraFollow cameraFollow;

    bool isSetup = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneChange;
        SceneManager.LoadScene("Game");
    }

    private void OnSceneChange(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(scene.name);
        Setup();
    }

    private void Setup()
    {
        managerUI = FindObjectOfType<UIManager>();
        player = FindObjectOfType<Player>();
        lightSystem = FindObjectOfType<LightSystem>();
        cameraFollow = FindObjectOfType<CameraFollow>();

        if (player == null)
        {
            Debug.LogWarning("Player not found");
        }
        isSetup = true;

        StartGame();
    }

    private void StartGame()
    {
        player.Reset();
        player.enabled = true;
        player.OnDie += EndGame;
        lightSystem.OnHit += player.Hit;
    }

    private void Update()
    {
        if (!isSetup)
            return;

        managerUI.energy.Set(player.energyPercent);
    }
    IEnumerator Spaw(float delay)
    {
        yield return new WaitForSeconds(delay);
    }

    private void EndGame()
    {
        SceneManager.LoadScene("Game");
        lightSystem.OnHit -= player.Hit;
        player.OnDie -= EndGame;
        player.enabled = false;

        ResetGame();

        StartCoroutine(Spaw(2f));
    }

    private void ResetGame()
    {
        player.Reset();
        cameraFollow.distance = new Vector3(0, 10, -9);
    }
}
