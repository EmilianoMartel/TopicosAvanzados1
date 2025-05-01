using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientManager : MonoBehaviour
{
    [SerializeField] private CoffeeShopManager _shopManager;
    [SerializeField] private Client _clientPrefab;

    private List<Client> _actualClients = new();

    private void OnEnable()
    {
        _shopManager.CreateOrder += CreateClient;
    }

    private void OnDisable()
    {
        _shopManager.CreateOrder -= CreateClient;
    }

    public Client GetCorrectClient(OrderStruct order)
    {
        foreach (Client client in _actualClients)
        {
            if(client.CompareOrder(order))
                return client;
        }

        return null;
    }

    private void RemoveClient(Client client)
    {
        if(_actualClients.Contains(client))
            _actualClients.Remove(client);

        client.DesactivateClient -= RemoveClient;
    }

    private void CreateClient(OrderStruct order)
    {
        Client temp = Instantiate(_clientPrefab);
        temp.transform.parent = transform;
        temp.SetOrder(order);
        _actualClients.Add(temp);

        temp.DesactivateClient += RemoveClient;
    }
}
