using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBckgrnd : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector2.left * 3.5f * Time.deltaTime);
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
