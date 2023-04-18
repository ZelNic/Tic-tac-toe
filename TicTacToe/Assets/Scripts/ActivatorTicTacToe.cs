using UnityEngine;

public class ActivatorTicTacToe : MonoBehaviour
{
    [SerializeField] private GameObject _crossGO;
    [SerializeField] private GameObject _noGO;  
    public void ActiveTicToe(bool value)
    {
        switch (value)
        {
            case true:
                if (_noGO.activeInHierarchy == false) _noGO.SetActive(true);
                break;
            case false:
                if (_crossGO.activeInHierarchy == false) _crossGO.SetActive(true);
                break;
        }
    }


}
