using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DecoratorView : MonoBehaviour
{
    [SerializeField] private Toggle _checkMark;
    [SerializeField] private TMP_Text _text;

    private ItemDecoratorSO _item;
    private bool _checkMarkValue = false;

    private void OnEnable()
    {
        _checkMark.onValueChanged.AddListener(HandleValueChanged);
    }

    private void OnDisable()
    {
        _checkMark.onValueChanged.RemoveAllListeners();
    }

    private void Awake()
    {
        ValidateReferences();
    }

    public void SetItem(ItemDecoratorSO item)
    {
        _checkMark.isOn = false;
        _item = item;
        _text.text = item.DecoratorShow();
    }

    /// <summary>
    /// If this function return null the checkmark is false.
    /// </summary>
    /// <returns></returns>
    public ItemDecoratorSO GetItem()
    {
        if(_checkMarkValue)
            return _item;

        return null;
    }

    private void HandleValueChanged(bool isTrue)
    {
        _checkMarkValue = isTrue;
    }

    private void ValidateReferences()
    {
        if (!_checkMark)
        {
            Debug.LogError($"{name}: Check mark is null.\nCheck and assigned one.");
            enabled = false;
            return;
        }
        if (!_text)
        {
            Debug.LogError($"{name}: Text is null.\nCheck and assigned one.");
            enabled = false;
            return;
        }
    }
}
