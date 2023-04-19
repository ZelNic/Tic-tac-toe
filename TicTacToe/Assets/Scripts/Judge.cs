using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    public static Judge Instance;
    public bool whoStep;  // false - cross; true - no
    public bool isPlay;
    
    private string[] codeMove = { "147", "258", "369", "789", "456", "123", "357", "159" };
    
    private List<string> _moveLogListCross = new List<string>();
    private string _codeCrossLog;
    private List<string> _moveLogListNo = new List<string>();
    private string _codeNoLog;
    
    private int _countStep;
    private bool _flagWinNo;
    private bool _flagWinCross;
    private bool _drow;

    private GameManager _gameManager;
    private Score _score;

    private void Awake()
    {
        Instance = this;
        isPlay = true;
        _gameManager = GetComponent<GameManager>();
        _score = GetComponent<Score>();
    }

    public void GetSetIsPlay()
    {
        isPlay = false;
        _gameManager.SubmitRequestForRestart();        
    }

    public void CheckWhoWin()
    {       
        if (_flagWinNo == true && _flagWinCross == false)
        {
            print("Победили нолики!");
            _score.СountNumberWins(true);
            GetSetIsPlay();
        }
        if (_flagWinNo == false && _flagWinCross == true)
        {
            print("Победили крестики!");
            _score.СountNumberWins(false);
            GetSetIsPlay();
        }
        if (_drow == true && _flagWinNo == false && _flagWinCross == false)
        {
            print("Ничья");
            GetSetIsPlay();
        }
    }

    public void ToCountStep()
    {
        _countStep++;
        if(_countStep == 9)
        {
            _drow = true;
            CheckWhoWin();
        }        
    }

    public void AddInListCross(string nameGO)
    {       
        _moveLogListCross.Add(nameGO);
        _codeCrossLog = null;
        for (int j = 0; j < _moveLogListCross.Count; j++)
            _codeCrossLog += _moveLogListCross[j];
        CheckSteps(false);
        ToCountStep();
    }
    public void AddInListNo(string nameGO)
    {
        _moveLogListNo.Add(nameGO);
        _codeNoLog = null;
        for (int j = 0; j < _moveLogListNo.Count; j++)
            _codeNoLog += _moveLogListNo[j];
        CheckSteps(true);
        ToCountStep();
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

