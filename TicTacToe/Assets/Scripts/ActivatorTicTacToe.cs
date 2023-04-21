using System;
using UnityEngine;

public class ActivatorTicTacToe : MonoBehaviour
{
    public static Action<string> onActive;
    public static Action<bool> onSetStatus;
    [SerializeField] private GameObject _crossGO;
    [SerializeField] private GameObject _noGO;
    private Collider2D _collider;
    private string nameThisGO;

    public void Awake()
    {
        nameThisGO = gameObject.name;
        _collider = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        SwitchPlayer.onGetStatusWhoStep += ActiveTicTac;
        GameManager.onSetActiveFalse += DeactiveGO;
        GameManager.onSetActiveTrue += SwitchCollider2D;
    }

    private void DeactiveGO()
    {
        _crossGO.SetActive(false);
        _noGO.SetActive(false);        
    }

    private void SwitchCollider2D(bool value)
    {
        _collider.enabled = value;
    }

    public void OnMouseDown()
    {
        onActive.Invoke(nameThisGO);
    }

    public void ActiveTicTac(string id, bool value)
    {
        if (id == nameThisGO)
        {
            switch (value)
            {
                case true:
                    if (!_noGO.activeInHierarchy && !_crossGO.activeInHierarchy)
                    {
                        _noGO.SetActive(true);
                        onSetStatus.Invoke(false);
                        Judge.onWriteStep?.Invoke(nameThisGO, value);
                    }
                    break;
                case false:
                    if (!_crossGO.activeInHierarchy && !_noGO.activeInHierarchy)
                    {
                        _crossGO.SetActive(true);
                        onSetStatus.Invoke(true);
                        Judge.onWriteStep?.Invoke(nameThisGO, value);
                    }
                    break;
            }
        }
    }
}
