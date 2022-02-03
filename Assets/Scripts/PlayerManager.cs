using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{

    int index = 0;
    private PlayerInputManager manager;
    [SerializeField]
    List<GameObject> players = new List<GameObject>();
    void Start()
    {
        index = Random.Range(0, players.Count);
        manager = GetComponent<PlayerInputManager>();
        manager.playerPrefab = players[index];
    }
    public void Player()
    {
        index = Random.Range(0, players.Count);
        if(index >= players.Count)
        {
            index = 0;
        }
    }
}
