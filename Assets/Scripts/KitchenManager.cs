using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class KitchenManager : MonoBehaviour
{
    [SerializeField] private CoffeeShopManager _shopManager;
    [SerializeField] private Order _orderPrefab;

    [Header("View")]
    [SerializeField] private Transform _contentTransform;

    //public List<DiscountRules> Discounts;

    private List<Order> _currentOrderns = new();
    private List<Order> _desactivatedOrders = new();

    public Action<OrderStruct> OrderFinished;

    private void OnEnable()
    {
        _shopManager.CreateOrder += HandleStartOrder;
    }

    private void OnDisable()
    {
        _shopManager.CreateOrder -= HandleStartOrder;

        foreach (var item in _currentOrderns)
        {
            item.OrderFinished -= HandleFinishOrder;
        }
        foreach (var desc in _desactivatedOrders)
        {
            desc.OrderFinished -= HandleFinishOrder;
        }
    }

    private void HandleStartOrder(OrderStruct order)
    {
        Order viewOrder = SelectOrderView();
        viewOrder.gameObject.SetActive(true);
        viewOrder.SetOrder(order);
    }

    private void HandleFinishOrder(Order order, OrderStruct orderInfo)
    {
        OrderFinished?.Invoke(orderInfo);

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
            order.OrderFinished += HandleFinishOrder;
        }
        else
        {
            order = _desactivatedOrders[0];
            _desactivatedOrders.RemoveAt(0);
        }

        return order;
    }
}
