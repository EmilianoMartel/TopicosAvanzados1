using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public OrderStruct orderInfo;

    public Action<Order> OrderFinished;

    public void Prepare(float timeToPrepare)
    {
        StartCoroutine(WaitForComplete(timeToPrepare));
    }

    public IEnumerator WaitForComplete(float timeToPrepare)
    {
        yield return new WaitForSeconds(timeToPrepare);
        OrderFinished?.Invoke(this);
    }
}
