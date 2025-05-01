using System.Collections;
using UnityEngine;

public class Waitress : MonoBehaviour
{
    [SerializeField] private ClientManager _clientManager;
    [SerializeField] private WaitressManager _waitressManager;
    [SerializeField] private float _couldDownWork = 2f;

    private bool _canTakeOrder = true;
    private bool _isWorking = false;

    private void OnEnable()
    {
        _waitressManager.CallWaitress += HandleWaitressManager;
    }

    private void OnDisable()
    {
        _waitressManager.CallWaitress -= HandleWaitressManager;
    }

    private void HandleWaitressManager()
    {
        if(_canTakeOrder && !_isWorking)
        {
            OrderStruct order = _waitressManager.GetOrder();

            if(order.IDOrder != -1)
            {
                Debug.Log($"{name}: I take order n° {order.IDOrder}");
                _isWorking = true;
                StartCoroutine(WorkProcess(order));
            }
        }
    }

    private IEnumerator WorkProcess(OrderStruct order)
    {
        yield return new WaitForSeconds(_couldDownWork);

        Client client = _clientManager.GetCorrectClient(order);

        string fullMessage = order.OrderDescription;

        if (client != null)
        {
            DiscountStruct discountToAdd = new();

            for (int i = 0; i < _waitressManager.discounts.Count; i++)
            {
                discountToAdd = _waitressManager.discounts[i].GetDiscount(client,order);

                if (discountToAdd.Description != "")
                {
                    fullMessage += " Discount " + discountToAdd.Description + ": " + discountToAdd.Discount.ToString("F2");
                    order.FullPrice -= discountToAdd.Discount;
                }
            }

            client.ReciveMyOrder();

            Debug.Log($"{name}: {fullMessage} \n Total: {order.FullPrice}");
        }

        _isWorking = false;
    }
}
