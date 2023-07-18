using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    SpawnerManager spawner;
    BoardManager board;

    private void Start()
    {
        spawner = GameObject.FindObjectOfType<SpawnerManager>();
        board = GameObject.FindObjectOfType<BoardManager>();
    }
}
