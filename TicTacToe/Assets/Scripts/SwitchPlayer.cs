using System;
using UnityEngine;

public class SwitchPlayer : MonoBehaviour
{
    public static Action<string,bool> onGetStatusWhoStep;  
    public static Func<bool> onSwitchPlayer;
    [SerializeField] private GameObject _crossSprite;
    [SerializeField] private GameObject _noSprite;
    private bool _crossOrOn;
    public bool CrossOrOn
    {
        get { return _crossOrOn; }
        set { _crossOrOn = value; }
    }

    private void Start()
    {
        DecideWhoGoes();
    }

    public void Update()
    {
        print(CrossOrOn);
    }

    public void OnEnable()
    {
        ActivatorTicTacToe.onActive += SetStatus;
        ActivatorTicTacToe.onSetStatus += ChangeStatusSwitchPlayer;
    }
    private void DecideWhoGoes()
    {
        int temp = UnityEngine.Random.Range(0, 2);
        if (temp == 0)
        {
            CrossOrOn = false;
            StepCross();
        }
        if (temp == 1)
        {
            CrossOrOn = true;
            StepNo();
        }
    }
    //вынести в отдельный скрипт
    public void StepCross()
    {
        _crossSprite.SetActive(true);
        _noSprite.SetActive(false);
    }
    public void StepNo()
    {
        _crossSprite.SetActive(false);
        _noSprite.SetActive(true);
    }
    public void ChangeStatusSwitchPlayer(bool value)
    {
        if (value == true)
        {                    
            CrossOrOn = value;            
            StepNo();
        }
        if (value == false)
        {
            CrossOrOn = value;           
            StepCross();
        }
    }
    public void SetStatus(string id)
    {
        onGetStatusWhoStep?.Invoke(id, CrossOrOn);       
    }
}
