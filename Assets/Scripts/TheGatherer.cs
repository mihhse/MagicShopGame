using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheGatherer : MonoBehaviour
{
    [SerializeField] private Transform[] itemSpawnLocations;
    [SerializeField] private GameObject[] itemsToSpawn;
    [SerializeField] private GameObject rotationReference;
    private bool tableOccupied = false;
    [SerializeField] private float waitForNewPatch;
    [SerializeField] private GameObject environment;

    internal void Interact()
    {
        if (!tableOccupied)
        {
            Debug.Log("Spawning");
            for (int i = 0; i < itemSpawnLocations.Length; i++)
            {
                var spawnedItem = Instantiate(itemsToSpawn[Random.Range(0, itemsToSpawn.Length)],
                            itemSpawnLocations[i].position,
                            rotationReference.transform.rotation);
                spawnedItem.transform.parent = environment.transform;
            }
            tableOccupied = true;
            StartCoroutine(WaitForNewItems());
        }
        else return;
    }

    IEnumerator WaitForNewItems()
    {
        yield return new WaitForSeconds(waitForNewPatch*60);
        tableOccupied = false;
    }
}
