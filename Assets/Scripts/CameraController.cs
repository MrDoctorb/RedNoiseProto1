using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject p1, p2;
    void Start()
    {
        PlayerController[] players = FindObjectsOfType<PlayerController>();
        p1 = players[0].gameObject;
        p2 = players[1].gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos1 = p1.transform.position;
        Vector2 pos2 = p2.transform.position;
        transform.position = new Vector3((pos1.x + pos2.x)/2, (pos1.y + pos2.y)/2, -10);
    }
}
