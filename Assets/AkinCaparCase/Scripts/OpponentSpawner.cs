using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPlace;
    [SerializeField] private List<GameObject> opponents;
    private float timeToNextSpawn;
    private int opponentIndex;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTeammate());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddToPool(GameObject teammate)
    {
        opponents.Add(teammate);
        teammate.gameObject.SetActive(false);
    }

    private void RemoveFromPool(int index)
    {
        opponents.Remove(opponents[index]);
    }

    IEnumerator SpawnTeammate()
    {
        timeToNextSpawn = Random.Range(2f, 5f);
        opponentIndex = Random.Range(0, opponents.Count);

        opponents[opponentIndex].SetActive(true);
        opponents[opponentIndex].transform.position = new Vector3(spawnPlace.position.x, 0, 1);
        RemoveFromPool(opponentIndex);

        yield return new WaitForSeconds(timeToNextSpawn);
        StartCoroutine(SpawnTeammate());
    }
}
