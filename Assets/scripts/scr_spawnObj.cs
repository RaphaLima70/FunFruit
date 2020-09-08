using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_spawnObj : MonoBehaviour
{
    public float spawnRate;
    public GameObject[] conjuntos;

    public scr_gerenciador linkG;

    private void Awake()
    {
        linkG = GameObject.Find("gerenciador").GetComponent<scr_gerenciador>();
    }

    void Update()
    {
        if (spawnRate <= 0)
        {
            Spawn();
        }
        else
        {
            spawnRate -= Time.deltaTime;
        }
    }

    private void Spawn()
    {
        Vector3 spawnPosition;

        spawnPosition = new Vector3(Random.Range(-1.8f, 1.8f), transform.position.y, transform.position.z);

        Instantiate((conjuntos[Random.Range(0, conjuntos.Length)]), spawnPosition, transform.rotation);
        spawnRate = linkG.spawnRateG;
    }
}
