using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenManager : MonoBehaviour
{
    [SerializeField] private Order _orderPrefab;

    [Header("View")]
    [SerializeField] private Transform _contentTransform;

    private List<Order> _currentOrderns = new();
    private List<Order> _desactivatedOrders = new();

    public Action<OrderStruct> OrderFinished;

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    private void HandleStartOrder(OrderStruct order)
    {
        Order viewOrder = SelectOrderView();
        viewOrder.SetOrder(order);
    }

    private void HandleFinishOrder(Order order)
    {
        //OrderFinished?.Invoke(order.orderInfo);

        if (_currentOrderns.Contains(order))
            _currentOrderns.Remove(order);

        if (!_desactivatedOrders.Contains(order))
            _desactivatedOrders.Add(order);

        order.gameObject.SetActive(false);
    }

    private Order SelectOrderView()
    {
        Order order = null;

        if (_desactivatedOrders.Count == 0)
        {
            order = Instantiate(_orderPrefab, _contentTransform);
        }
        else
        {
            order = _desactivatedOrders[0];
            _desactivatedOrders.RemoveAt(0);
        }

        return order;
    }
}
