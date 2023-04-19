using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _noScore;
    [SerializeField] private Text _crossScore;
    private int _countWinNo = 0;
    private int _countWinCross = 0;
    private int _totalScoreWinNo;
    private int _totalScoreWinCross;

    private void Start()
    {
        CheckPlayerPrefs();
    }
    private void CheckPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("TotalScoreWinCross"))
        {
            _totalScoreWinCross = PlayerPrefs.GetInt("TotalScoreWinCross", _totalScoreWinCross);
            _crossScore.text = _totalScoreWinCross.ToString();

        }
        else _crossScore.text = _countWinCross.ToString();

        if (PlayerPrefs.HasKey("TotalScoreWinNo"))
        {
            _totalScoreWinNo = PlayerPrefs.GetInt("TotalScoreWinNo", _totalScoreWinNo);
            _noScore.text = _totalScoreWinNo.ToString();
        }
        else _noScore.text = _countWinNo.ToString();
    }
    public void ÑountNumberWinsNo()
    {
        _countWinNo++;
        UpdateScoreNo();
    }
    public void ÑountNumberWinsCross()
    {
        _countWinCross++;
        UpdateScoreCross();
    }
    public void UpdateScoreNo()
    {
        _totalScoreWinNo += _countWinNo;
        PlayerPrefs.SetInt("TotalScoreWinNo", _totalScoreWinNo);
        PlayerPrefs.Save();
        _noScore.text = _totalScoreWinNo.ToString();
    }

    public void UpdateScoreCross()
    {
        _totalScoreWinCross += _countWinCross;
        PlayerPrefs.SetInt("TotalScoreWinCross", _totalScoreWinCross);
        PlayerPrefs.Save();
        _crossScore.text = _totalScoreWinCross.ToString();
    }
}
