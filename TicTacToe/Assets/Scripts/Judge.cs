using System;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    public static Action<string, bool> onWriteStep;

    public bool isPlay;

    private string[] codeMove = { "147", "258", "369", "789", "456", "123", "357", "159" };

    private List<string> _moveLogListCross = new List<string>();
    private string _codeCrossLog;
    private List<string> _moveLogListNo = new List<string>();
    private string _codeNoLog;

    private int _countStep;
    private bool _drow;
    private bool _flagWinNo;
    private bool _flagWinCross;
    

    private void Awake()
    {
        isPlay = true;       
    }

    private void OnEnable()
    {
        onWriteStep += AddInList;
        GameManager.onSetActiveTrue += ResetFields;     
    }

    private void ResetFields(bool value)
    {
        _moveLogListCross.Clear();
        _moveLogListNo.Clear();
        _countStep = 0;
        _drow = false;
        _flagWinNo = false;
        _flagWinCross = false;
        isPlay = true;
    }

    public void ResetGame()
    {
        isPlay = false;
        GameManager.onRestartGame?.Invoke();
    }

    public void CheckWhoWin()
    {
        if (_flagWinNo == true && _flagWinCross == false)
        {
            Score.onIncreaseScore(true);
            ResetGame();
        }
        if (_flagWinNo == false && _flagWinCross == true)
        {
            Score.onIncreaseScore(false);
            ResetGame();
        }
        if (_drow == true && _flagWinNo == false && _flagWinCross == false)
        {
            ResetGame();
        }
    }

    public void ToCountStep()
    {
        _countStep++;
        if (_countStep == 9)
        {
            _drow = true;
            CheckWhoWin();
        }
    }

    public void AddInList(string id, bool value)
    {
        switch (value)
        {
            case true:
                _moveLogListCross.Add(id);
                _codeCrossLog = null;
                for (int j = 0; j < _moveLogListCross.Count; j++)
                    _codeCrossLog += _moveLogListCross[j];
                CheckSteps(false);
                ToCountStep();
                break;

            case false:

                _moveLogListNo.Add(id);
                _codeNoLog = null;
                for (int j = 0; j < _moveLogListNo.Count; j++)
                    _codeNoLog += _moveLogListNo[j];
                CheckSteps(true);
                ToCountStep();
                break;
        }
    }

    public void CheckSteps(bool value)
    {
        int coinCidenceCross;
        int coinCidenceNo;
        for (int i = 0; i < codeMove.Length; i++)
        {
            coinCidenceCross = 0;
            coinCidenceNo = 0;
            for (int j = 0; j < codeMove[i].Length; j++)
            {
                if (value == false)
                {
                    for (int k = 0; k < _codeCrossLog.Length; k++)
                    {
                        if (_codeCrossLog[k] == codeMove[i][j])
                        {
                            coinCidenceCross++;
                            if (coinCidenceCross == 3)
                            {
                                _flagWinCross = true;
                                CheckWhoWin();
                            }
                        }
                    }
                }
                else
                {
                    for (int k = 0; k < _codeNoLog.Length; k++)
                    {
                        if (_codeNoLog[k] == codeMove[i][j])
                        {
                            coinCidenceNo++;
                            if (coinCidenceNo == 3)
                            {
                                _flagWinNo = true;
                                CheckWhoWin();
                            }
                        }

                    }
                }
            }
        }
    }
}

