using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] GameObject spawnObject;
    [SerializeField] Vector2 newSpawnPos;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerController>())
        {
            spawnObject.transform.position = newSpawnPos;
        }
    }
}
