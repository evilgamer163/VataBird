using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBckgrnd : MonoBehaviour
{
    [SerializeField] GameObject[] sprites;
     
    void Start()
    {
        StartCoroutine(Spawner());
    }

    void Update()
    {
        
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            Instantiate(sprites[Random.Range(0, sprites.Length)], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
        }
    }
}
