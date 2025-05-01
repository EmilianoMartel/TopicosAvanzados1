using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEditor.Experimental.GraphView;

public class OrderSelectorView : MonoBehaviour
{
    [SerializeField] private List<ItemMenuSO> _menuItem;
    [SerializeField] private TMP_Dropdown _dropDown;
    [SerializeField] private DecoratorView _decoratorViewPrefab;
    [SerializeField] private Transform _contentParent;

    private List<DecoratorView> _decoratorViewsActivated = new();
    private List<DecoratorView> _decoratedViewsDesactivated = new();

    private int _currentIndex = 0;

    private void OnEnable()
    {
        _dropDown.onValueChanged.AddListener(HandleValueDropDownChanged);   
    }

    private void OnDisable()
    {
        _dropDown.onValueChanged.RemoveListener(HandleValueDropDownChanged);
    }

    private void Awake()
    {
        ValidateReferences();
        SetDrown();
        HandleValueDropDownChanged(0);
    }

    public string GetOrder()
    {
        MenuItem menuItem = _menuItem[_currentIndex].GetMenuItem();

        Drink drink = menuItem as Drink;
        Food food = menuItem as Food;

        if (drink != null)
        {
            for (int i = 0; i < _decoratorViewsActivated.Count; i++)
            {
                ItemDecoratorSO temp = _decoratorViewsActivated[i].GetItem();
                if (temp != null)
                {
                    drink = temp.GetDrinkDecorator(drink);
                }
            }

            return drink.GetDescription() + "price: " + drink.GetPrice().ToString("F2");
        }
        if (food != null)
        {
            for (int i = 0; i < _decoratorViewsActivated.Count; i++)
            {
                ItemDecoratorSO temp = _decoratorViewsActivated[i].GetItem();
                if (temp != null)
                {
                    food = temp.GetFoodDecorator(food);
                }
            }

            return food.GetDescription() + " price: " + food.GetPrice().ToString("F2");
        }

        return "";
    }

    private void SetDrown()
    {
        List<string> options = new List<string>();

        foreach (ItemMenuSO item in _menuItem)
        {
            options.Add(item.ItemID);
        }

        _dropDown.ClearOptions();
        _dropDown.AddOptions(options);
    }

    private void HandleValueDropDownChanged(int index)
    {
        _currentIndex = index;

        foreach (var view in _decoratorViewsActivated)
        {
            view.gameObject.SetActive(false);
            _decoratedViewsDesactivated.Add(view);
        }
        _decoratorViewsActivated.Clear();

        CreatedDecoratorList(_menuItem[index]);
    }

    private void CreatedDecoratorList(ItemMenuSO item)
    {
        foreach (var decorator in item.ItemDecorators)
        {
            DecoratorView decoratorView = SelectDecoratorView();
            decoratorView.SetItem(decorator);

            decoratorView.gameObject.SetActive(true);
            _decoratorViewsActivated.Add(decoratorView);
        }
    }

    private DecoratorView SelectDecoratorView()
    {
        DecoratorView decoratorView = null;

        if (_decoratedViewsDesactivated.Count == 0)
        {
            decoratorView = Instantiate(_decoratorViewPrefab, _contentParent);
        }
        else
        {
            decoratorView = _decoratedViewsDesactivated[0];
            _decoratedViewsDesactivated.RemoveAt(0);
        }

        return decoratorView;
    }

    private void ValidateReferences()
    {
        if (!_dropDown)
        {
            Debug.LogError($"{name}: DropDown is null.\nCheck and assigned one.");
            enabled = false;
            return;
        }
        if (!_decoratorViewPrefab)
        {
            Debug.LogError($"{name}: Decorator view is null.\nCheck and assigned one.");
            enabled = false;
            return;
        }
        if (!_contentParent)
        {
            Debug.LogError($"{name}: Content Parent is null.\nCheck and assigned one.");
            enabled = false;
            return;
        }
    }
}