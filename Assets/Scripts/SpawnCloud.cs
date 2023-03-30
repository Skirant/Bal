using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCloud : MonoBehaviour
{
    [SerializeField] GameObject[] CloudPrefab;
    [SerializeField] float secondSpawn = 1f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;
    [SerializeField] float indent;

    private void Start()
    {
        StartCoroutine(CloudSpawn());
    }

    IEnumerator CloudSpawn()
    {
        while (true)
        {
            var wanted = Random.Range(minTras, maxTras);
            var viewportPosition = new Vector3(-indent, wanted, -Camera.main.transform.position.z);
            var position = Camera.main.ViewportToWorldPoint(viewportPosition);
            GameObject gameObject = Instantiate(CloudPrefab[Random.Range(0, CloudPrefab.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 30f);
        }
    }
}
