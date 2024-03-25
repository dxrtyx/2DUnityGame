using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject[] boxes;
    public int clocker;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnTimer());
    }
    void Spawn()
    {
        int boxId = Random.Range(0, boxes.Length);
        Instantiate(boxes[boxId], new Vector3(transform.position.x, transform.position.y + 10f), transform.rotation);
        if (clocker % 3 == 0)
        {
            Instantiate(boxes[boxId], new Vector3(Random.Range(-8f, 8f), transform.position.y + 10f), transform.rotation);
        }
        StartCoroutine(spawnTimer());
    }

    private IEnumerator spawnTimer()
    {
        clocker++;
        yield return new WaitForSeconds(1f);
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
