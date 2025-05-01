using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Order : MonoBehaviour
{
    [SerializeField] private TMP_Text _orderText;

    private OrderStruct _orderInfo;

    public Action<Order, OrderStruct> OrderFinished;

    public void SetOrder(OrderStruct orderInfo)
    {
        _orderInfo = orderInfo;

        _orderText.text = "Order N° " + _orderInfo.IDOrder.ToString() + " = ";

        foreach (var item in orderInfo.MenuItems)
        {
            _orderText.text += item.GetDescription() + " - ";
        }

        int timeToPrepare = orderInfo.MenuItems.Count;

        Prepare(timeToPrepare);
    }

    private void Prepare(float timeToPrepare)
    {
        StartCoroutine(WaitForComplete(timeToPrepare));
    }

    private IEnumerator WaitForComplete(float timeToPrepare)
    {
        yield return new WaitForSeconds(timeToPrepare);
        OrderFinished?.Invoke(this, _orderInfo);
    }
}
