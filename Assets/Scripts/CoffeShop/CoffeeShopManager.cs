using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoffeeShopManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private OrderSelectorView _orderSelectorView;

    [Header("View")]
    [SerializeField] private Button _addButton;
    [SerializeField] private Button _orderButon;
    [SerializeField] private TMP_Text _currentOrder;
    [SerializeField] private TMP_Text _orderList;

    private int _ordersCount = 1;
    private string _fullOrder = "";
    private OrderStruct _orderStruct;

    public Action<OrderStruct> CreateOrder;

    private void OnEnable()
    {
        _addButton.onClick.AddListener(HandleAddOrder);
        _orderButon.onClick.AddListener(HandleOrder);
    }

    private void OnDisable()
    {
        _addButton.onClick.RemoveListener(HandleAddOrder);
        _orderButon.onClick.RemoveListener(HandleOrder);
    }

    private void Awake()
    {
        ValidateReferences();
    }

    private void HandleAddOrder()
    {
        if (_fullOrder == "")
        {
            _fullOrder = $"Order N°{_ordersCount}: \n";
            _orderStruct.IDOrder = _ordersCount;
            _orderStruct.MenuItems = new();
        }

        _fullOrder += _orderSelectorView.GetOrder(out MenuItem menu);
        _fullOrder += "\n";

        _orderStruct.MenuItems.Add(menu);

        _currentOrder.text = "Current Order: \n" + _fullOrder;
    }

    private void HandleOrder()
    {
        if(_fullOrder == "")
            return;

        _orderList.text += _fullOrder;

        CreateOrder?.Invoke(_orderStruct);

        _orderStruct = new();
        _ordersCount++;
        _fullOrder = "";
    }

    private void ValidateReferences()
    {
        if (!_orderSelectorView)
        {
            Debug.LogError($"{name}: Order view is null.\nCheck and assigned one.");
            enabled = false;
            return;
        }
        if (!_addButton)
        {
            Debug.LogError($"{name}: AddButton is null.\nCheck and assigned one.");
            enabled = false;
            return;
        }
        if (!_orderButon)
        {
            Debug.LogError($"{name}: OrderButton is null.\nCheck and assigned one.");
            enabled = false;
            return;
        }
        if (!_orderList)
        {
            Debug.LogError($"{name}: OrderList is null.\nCheck and assigned one.");
            enabled = false;
            return;
        }
    }
}