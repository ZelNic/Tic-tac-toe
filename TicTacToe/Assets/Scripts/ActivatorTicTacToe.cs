using UnityEngine;

public class ActivatorTicTacToe : MonoBehaviour
{
    [SerializeField] private GameObject _crossGO;
    [SerializeField] private GameObject _noGO;
    private string nameThisGO;

    public void Awake()
    {
        nameThisGO = this.gameObject.name;
    }

    public void OnMouseDown()
    {
        if (SwitchPlayer._switchPlayer == true)
        {
            ActiveNo();
        }

        if (SwitchPlayer._switchPlayer == false)
        {
            ActiveCross();
        }
    }
    public void ActiveNo()
    {
        if (_noGO.activeInHierarchy == false && _crossGO.activeInHierarchy == false)
        {
            _noGO.SetActive(true);
            SwitchPlayer._switchPlayer = false;            
            Judge.Instance.AddInListNo(nameThisGO);
        }
    }
    public void ActiveCross()
    {
        if (_crossGO.activeInHierarchy == false && _noGO.activeInHierarchy == false)
        {
            _crossGO.SetActive(true);
            SwitchPlayer._switchPlayer = true;
            Judge.Instance.AddInListCross(nameThisGO);            
        }
    }
}
