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
        if (Judge.Instance.whoStep == true)
        {
            ActiveNo();
        }

        if (Judge.Instance.whoStep == false)
        {
            ActiveCross();
        }
    }
    public void ActiveNo()
    {
        if (_noGO.activeInHierarchy == false && _crossGO.activeInHierarchy == false)
        {
            _noGO.SetActive(true);
            Judge.Instance.whoStep = false;            
            Judge.Instance.AddInListNo(nameThisGO);
        }
    }
    public void ActiveCross()
    {
        if (_crossGO.activeInHierarchy == false && _noGO.activeInHierarchy == false)
        {
            _crossGO.SetActive(true);
            Judge.Instance.whoStep = true;
            Judge.Instance.AddInListCross(nameThisGO);            
        }
    }
}
