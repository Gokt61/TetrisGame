using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    SpawnerManager spawner;
    BoardManager board;

    private ShapeManager aktifSekil;

    private void Start()
    {
        spawner = GameObject.FindObjectOfType<SpawnerManager>();
        board = GameObject.FindObjectOfType<BoardManager>();

        if (spawner != null)
        {
            if (aktifSekil == null)
            {
                aktifSekil = spawner.SekilOlsuturFNC();
                aktifSekil.transform.position = VectoruIntYapFNC(aktifSekil.transform.position);
            }
        }
    }

    private void Update()
    {
        if (!board || !spawner)
        {
            return;
        }

        if (aktifSekil)
        {
            aktifSekil.AssagiHareketFNC();
        }
    }
    Vector2 VectoruIntYapFNC(Vector2 vector)
    {
        return new Vector2(Mathf.Round(vector.x),Mathf.Round(vector.y));
    }
}
