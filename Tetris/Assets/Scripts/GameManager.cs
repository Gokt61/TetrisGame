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

    [Range(0.02f, 2)]
    [SerializeField] float sagSolDonmeSuresi = 0.25f;

    float sagSolDonmeSayac;

    [Range(0.02f, 2)]
    [SerializeField] float asagiTusaBasmaSuresi = 0.25f;

    float asagiTusaBasmaSayaci;

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
        if (!board || !spawner || !aktifSekil)
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

            if (!board.GecerliPozisyondami(aktifSekil))
            {
                aktifSekil.SolaHareketetFNC();
            }
        }
        else if (Input.GetKeyDown("left") || (Input.GetKey("left") && Time.time > sagSolTusaBasmaSayac))
        {
            aktifSekil.SolaHareketetFNC();
            sagSolTusaBasmaSayac = Time.time + sagSolTusaBasmaSuresi;

            if (!board.GecerliPozisyondami(aktifSekil))
            {
                aktifSekil.SagaHareketetFNC();
            }
        }
        else if ((Input.GetKeyDown("up") && Time.time > sagSolDonmeSayac))
        {
            aktifSekil.SagaDonFNC();
            sagSolDonmeSayac = Time.time + sagSolDonmeSuresi;

            if (!board.GecerliPozisyondami(aktifSekil))
            {
                aktifSekil.SagaHareketetFNC();
            }
        }
        else if (Time.time > asagiInmeSayac|| (Input.GetKey("down") && Time.time > asagiTusaBasmaSayaci))
        {
            asagiInmeSayac = Time.time + asagiInmeSuresi;
            asagiTusaBasmaSayaci = Time.time + asagiTusaBasmaSuresi;

            if (aktifSekil)
            {
                aktifSekil.AssagiHareketFNC();

                if (!board.GecerliPozisyondami(aktifSekil))
                {
                    YerlestigiFNC();
                }
            }
        }     
    }

    void YerlestigiFNC()
    {
        sagSolTusaBasmaSayac = Time.time;
        asagiTusaBasmaSayaci = Time.time;
        sagSolDonmeSayac = Time.time;

        aktifSekil.YukariHareketFNC();

        board.SekliIzgaraIcineAlFNC(aktifSekil);

        if (spawner)
        {
            aktifSekil = spawner.SekilOlsuturFNC();
        }
    }

    Vector2 VectoruIntYapFNC(Vector2 vector)
    {
        return new Vector2(Mathf.Round(vector.x),Mathf.Round(vector.y));
    }
}
