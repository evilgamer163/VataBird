using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMove : MonoBehaviour
{
    [SerializeField] GameObject[] sprites;
    Vector2 randomPos;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    void Update()
    {
        float posY = Random.Range(-3.5f, 4.5f);
        randomPos = new Vector2(transform.position.x, posY);
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f);
            Instantiate(sprites[Random.Range(0, sprites.Length)], randomPos, Quaternion.identity);
            yield return new WaitForSeconds(.4f);
        }
    }
}
