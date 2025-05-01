using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenManager : MonoBehaviour
{

    public Action<OrderStruct> OrderFinished;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void HandleStartOrder()
    {

    }

    private void HandleFinishOrder(Order order)
    {
        OrderFinished?.Invoke(order.orderInfo);
    }
}
