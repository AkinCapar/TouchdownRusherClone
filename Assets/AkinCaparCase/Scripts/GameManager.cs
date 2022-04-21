using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int levelLength; // amount of chunks cycle
    public float gameSpeed;

    [SerializeField] private GameObject loseCanvas;
    [SerializeField] private GameObject winCanvas;

    [SerializeField] private GameObject spawners;

    [SerializeField] private GameObject fastCam;
    [SerializeField] private GameObject normalCam;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void StopSpawners()
    {
        spawners.SetActive(false);
    }

    public void WinGame()
    {
        StopSpawners();
        winCanvas.SetActive(true);
        gameSpeed = 0;
    }

    public void LoseGame()
    {
        StopSpawners();
        loseCanvas.SetActive(true);
        gameSpeed = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void SwitchToFastCam()
    {
        fastCam.SetActive(true);
        normalCam.SetActive(false);
    }

    public void SwitchToNormalCam()
    {
        fastCam.SetActive(false);
        normalCam.SetActive(true);
    }
}
