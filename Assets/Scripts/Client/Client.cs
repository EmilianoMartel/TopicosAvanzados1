using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    private bool _isMember;
    private OrderStruct _selfOrder;

    public Action<Client> DesactivateClient;

    private void Awake()
    {
        int isMember = UnityEngine.Random.Range(0,2);

        _isMember = isMember == 0;
    }

    public bool CompareOrder(OrderStruct order)
    {
        return _selfOrder.IDOrder == order.IDOrder; 
    }

    public bool GetIsMember() { return _isMember; }

    public void ReciveMyOrder()
    {
        Debug.Log($"{name}: Thanks!!");
        DesactivateClient?.Invoke(this);
    }

    public void SetOrder(OrderStruct selfOrder)
    {
        _selfOrder = selfOrder;
    }
}
