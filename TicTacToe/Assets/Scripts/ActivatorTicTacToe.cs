using UnityEngine;

public class ActivatorTicTacToe : MonoBehaviour
{
    [SerializeField] private GameObject _crossGO;
    [SerializeField] private GameObject _noGO;    

    public void Update()
    {
        print(SwitchPlayer._switchPlayer);
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
        }
    }

    public void ActiveCross()
    {
        if (_crossGO.activeInHierarchy == false && _noGO.activeInHierarchy == false)
        {
            _crossGO.SetActive(true);
            SwitchPlayer._switchPlayer = true;
        }
    }
}
