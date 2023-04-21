using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Action<bool> onIncreaseScore;
    [SerializeField] private Text _noScore;
    [SerializeField] private Text _crossScore;
    private int _totalScoreWinNo = 0;
    private int _totalScoreWinCross = 0;

    private void Start()
    {
        CheckPlayerPrefs();
    }

    private void OnEnable()
    {
        onIncreaseScore += CountNumberWins;
    }

    private void CheckPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("TotalScoreWinCross"))
        {
            _totalScoreWinCross = PlayerPrefs.GetInt("TotalScoreWinCross", _totalScoreWinCross);
            _crossScore.text = _totalScoreWinCross.ToString();

        }
        else _crossScore.text = "0";

        if (PlayerPrefs.HasKey("TotalScoreWinNo"))
        {
            _totalScoreWinNo = PlayerPrefs.GetInt("TotalScoreWinNo", _totalScoreWinNo);
            _noScore.text = _totalScoreWinNo.ToString();
        }
        else _noScore.text = "0";
    }

    public void CountNumberWins(bool noCross)
    {
        switch (noCross)
        {
            case true:
                _totalScoreWinNo += 1;
                _noScore.text = _totalScoreWinNo.ToString();
                PlayerPrefs.SetInt("TotalScoreWinNo", _totalScoreWinNo);
                PlayerPrefs.Save();
                break;

            case false:
                _totalScoreWinCross += 1;
                _crossScore.text = _totalScoreWinCross.ToString();
                PlayerPrefs.SetInt("TotalScoreWinCross", _totalScoreWinCross);
                PlayerPrefs.Save();
                break;
        }
    }
  

    public void UpdateScoreCross()
    {
        _totalScoreWinCross += 1;
        _crossScore.text = _totalScoreWinCross.ToString();
        PlayerPrefs.SetInt("TotalScoreWinCross", _totalScoreWinCross);
        PlayerPrefs.Save();
    }

    public void ResetTotalScoreForAllTime()
    {
        PlayerPrefs.DeleteAll();
        _totalScoreWinCross = 0;
        _totalScoreWinNo = 0;
        _crossScore.text = _totalScoreWinCross.ToString();
        _noScore.text = _totalScoreWinNo.ToString();
    }
}

