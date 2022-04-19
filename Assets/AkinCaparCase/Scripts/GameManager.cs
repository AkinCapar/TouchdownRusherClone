using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int levelLength; // amount of chunks cycle
    public float gameSpeed;

    [SerializeField] private GameObject spawners;

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
}
