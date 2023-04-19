using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{

    public static Judge Instance;
    public bool whoStep;  // false - cross; true - no
    private string[] codeMove = { "147", "258", "369", "789", "456", "123", "357", "159" };
    private List<string> _moveLogListCross = new List<string>();
    private string _codeCrossLog;
    private List<string> _moveLogListNo = new List<string>();
    private string _codeNoLog;
    private int _countStep;
    private bool _flagWinNo;
    private bool _flagWinCross;

    private void Awake()
    {
        Instance = this;
    }

    public void CheckWhoWin()
    {
        if (_countStep == 9 && _flagWinNo == false && _flagWinCross == false)
        {
            print("Ничья");
        }
        if (_flagWinNo == true && _flagWinCross == false)
        {
            print("Победили нолики!");
        }
        if (_flagWinNo == false && _flagWinCross == true)
        {
            print("Победили крестики!");
        }
    }

    public void AddInListCross(string nameGO)
    {
        _countStep++;
        _moveLogListCross.Add(nameGO);
        _codeCrossLog = null;
        for (int j = 0; j < _moveLogListCross.Count; j++)
            _codeCrossLog += _moveLogListCross[j];
        CheckSteps(false);
    }
    public void AddInListNo(string nameGO)
    {
        _countStep++;
        _moveLogListNo.Add(nameGO);
        _codeNoLog = null;
        for (int j = 0; j < _moveLogListNo.Count; j++)
            _codeNoLog += _moveLogListNo[j];
        CheckSteps(true);
    }

    public void CheckSteps(bool value)
    {
        CheckWhoWin();
        int coinCidenceCross;
        int coinCidenceNo;
        for (int i = 0; i < codeMove.Length; i++)
        {
            coinCidenceCross = 0;
            coinCidenceNo = 0;
            for (int j = 0; j < codeMove[i].Length; j++)
            {
                if(value == false)
                {
                    for (int k = 0; k < _codeCrossLog.Length; k++)
                    {
                        if (_codeCrossLog[k] == codeMove[i][j])
                        {
                            coinCidenceCross++;
                            if (coinCidenceCross == 3)
                            {
                                _flagWinCross = true;                                
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
                            }
                        }

                    }
                }
            }
        }
    }
}

