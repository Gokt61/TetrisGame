using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeManager : MonoBehaviour
{
    [SerializeField] private bool donebilirmi = true;


    public void SolaHareketetFNC()
    {
        transform.Translate(Vector3.left, Space.World);
    }
    public void SagaHareketetFNC()
    {
        transform.Translate(Vector3.right, Space.World);
    }

    public void AssagiHareketFNC()
    {
        transform.Translate(Vector3.down, Space.World);
    }
    public void YukariHareketFNC()
    {
        transform.Translate(Vector3.up, Space.World);
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
