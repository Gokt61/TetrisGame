using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField]private ShapeManager[] tumSekiller;


    public ShapeManager SekilOlsuturFNC()
    {
        int randomSekil = Random.Range(0,tumSekiller.Length);
        ShapeManager sekil = Instantiate(tumSekiller[randomSekil], transform.position,Quaternion.identity) as ShapeManager;

        if (sekil != null)
        {
            return sekil;
        }
        else
        {
            Debug.Log("Boþ dizi");
            return null;
        }
    } 
}
