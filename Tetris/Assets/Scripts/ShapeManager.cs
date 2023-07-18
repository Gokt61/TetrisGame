using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeManager : MonoBehaviour
{
    [SerializeField] private bool donebilirmi = true;

    private void Start()
    {
        //InvokeRepeating("AssagiHareketFNC",0f,0.25f);
        StartCoroutine(HareketRoutine());
    }

    public void SolaHareketetFNC()
    {
        transform.Translate(Vector3.left);
    }
    public void SagaHareketetFNC()
    {
        transform.Translate(Vector3.right);
    }

    public void AssagiHareketFNC()
    {
        transform.Translate(Vector3.down);
    }
    public void YukariHareketFNC()
    {
        transform.Translate(Vector3.up);
    }

    public void SagaDonFNC()
    {
        if (donebilirmi)
        {
            transform.Rotate(0, 0, -90);
        }
    }
    public void SolaDonFNC()
    {
        if (donebilirmi)
        {
            transform.Rotate(0, 0, 90);
        }
    }

    IEnumerator HareketRoutine()
    {
        while (true)
        {
            AssagiHareketFNC();
            yield return new WaitForSeconds(0.25f);
        }
    }
}
