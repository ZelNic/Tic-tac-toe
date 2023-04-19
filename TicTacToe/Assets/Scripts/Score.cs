using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _noScore;
    [SerializeField] private Text _crossScore;
    private int _countWinNo;
    private int _countWinCross;

    private void Start()
    {
        _noScore.text = _countWinNo.ToString();
        _crossScore.text = _countWinCross.ToString();
    }

    public void ÑountNumberWins(bool value)
    {
        if (value) _countWinNo++;
        else _countWinCross++;
        UpdateScore();
    }

    public void UpdateScore()
    {
        _noScore.text = _countWinNo.ToString();
        _crossScore.text = _crossScore.ToString();
    }
}
