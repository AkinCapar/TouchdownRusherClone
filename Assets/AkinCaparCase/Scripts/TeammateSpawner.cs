using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeammateSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPlace;
    [SerializeField] private List<GameObject> teammates;
    private float timeToNextSpawn;
    private int teammateIndex;

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
        teammates.Add(teammate);
        teammate.gameObject.SetActive(false);
    }

    private void RemoveFromPool(int index)
    {
        teammates.Remove(teammates[index]);
    }

    IEnumerator SpawnTeammate()
    {
        timeToNextSpawn = Random.Range(2f, 5f);
        teammateIndex = Random.Range(0, teammates.Count);

        teammates[teammateIndex].SetActive(true);
        teammates[teammateIndex].transform.position = new Vector3(spawnPlace.position.x, 0, -1);
        RemoveFromPool(teammateIndex);

        yield return new WaitForSeconds(timeToNextSpawn);
        StartCoroutine(SpawnTeammate());
    }
}
