using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitressManager : MonoBehaviour
{
    [SerializeField] private KitchenManager _kitchen;

    public List<DiscountRule> discounts;

    private List<OrderStruct> _orders = new();
    private object _orderCheackBuffer = new();

    public Action CallWaitress;

    private void OnEnable()
    {
        _kitchen.OrderFinished += HandleOrderFinished;
    }

    private void OnDisable()
    {
        _kitchen.OrderFinished -= HandleOrderFinished;
    }

    public OrderStruct GetOrder()
    {
        OrderStruct order = new();
        order.IDOrder = -1;

        lock (_orderCheackBuffer)
        {
            if (_orders.Count > 0)
            {
                order = _orders[0];
                _orders.Remove(order);
            }
        }

        return order;
    }

    private void HandleOrderFinished(OrderStruct order)
    {
        _orders.Add(order);
        Debug.Log($"{name}: I have a new order!, currenly i have {_orders.Count}");
        CallWaitress?.Invoke();
    }
}
