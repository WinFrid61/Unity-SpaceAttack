using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCoroutines : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject AsteroidPrefab;

    void Start()
    {
        StartCoroutine(CloneEnemyPrefab());
        StartCoroutine(CloneAsteroidPrefab());
    }
    IEnumerator CloneEnemyPrefab()
    {
        while (true)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-7.5f, 7.5f), 6.7f, -0.001f), Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
    }
    IEnumerator CloneAsteroidPrefab()
    {
        while (true)
        {
            Instantiate(AsteroidPrefab, new Vector3(9.89f, Random.Range(-4.1f, 4.1f), -0.0001f), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5, 9));
        }
    }

}
