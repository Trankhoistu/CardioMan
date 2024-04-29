using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpikes : MonoBehaviour
{
    [SerializeField] GameObject[] fallingSpikePrefab;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;
    [SerializeField] float zPosition = 0f;

    void Start()
    {
        StartCoroutine(SpikeSpawn());
    }

    IEnumerator SpikeSpawn()
    {
        while(true)
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y, zPosition);
            GameObject gameObject = Instantiate(fallingSpikePrefab[Random.Range(0, fallingSpikePrefab.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            // Destroys spikes after 3 seconds
            Destroy(gameObject, 3f);
        }
    }
}
