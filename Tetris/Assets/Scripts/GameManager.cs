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
    [SerializeField] private float asagiInmeSuresi = 0.25f;
    float asagiInmeSayac;
    [Range(0.02f, 2)]
    [SerializeField] float sagSolTusaBasmaSuresi = 0.25f;

    float sagSolTusaBasmaSayac;

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

        GirisKontrolFNC();
    }

    void GirisKontrolFNC()
    {
        if (Input.GetKeyDown("right") || (Input.GetKey("right") && Time.time > sagSolTusaBasmaSayac))
        {
            aktifSekil.SagaHareketetFNC();
            sagSolTusaBasmaSayac = Time.time + sagSolTusaBasmaSuresi;

            if (board.GecerliPozisyondami(aktifSekil))
            {
                print("Saða hareket ediyor.");
            }
            else
            {
                aktifSekil.SolaHareketetFNC();
            }
        }

        if (Time.time > asagiInmeSayac)
        {
            asagiInmeSayac = Time.time + asagiInmeSuresi;

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
