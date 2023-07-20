using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    SpawnerManager spawner;
    BoardManager board;

    private ShapeManager aktifSekil;

    [Header("SAYAÇLAR")]
    [Range(0.01f,2)]
    [SerializeField] private float spawnSuresi = 0.5f;
    float spawnSayac;

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

        if (Time.time > spawnSayac)
        {
            spawnSayac = Time.time + spawnSuresi;

            if (aktifSekil)
            {
                aktifSekil.AssagiHareketFNC();

                if (!board.GecerliPozisyondami(aktifSekil))
                {
                    aktifSekil.YukariHareketFNC();

                    board.SekliIzgaraIcineAlFNC(aktifSekil);

                    if (spawner)
                    {
                        aktifSekil = spawner.SekilOlsuturFNC();
                    }
                }
            }
        }
    }
    Vector2 VectoruIntYapFNC(Vector2 vector)
    {
        return new Vector2(Mathf.Round(vector.x),Mathf.Round(vector.y));
    }
}
