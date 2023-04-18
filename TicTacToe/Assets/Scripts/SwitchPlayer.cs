using UnityEngine;

public delegate void SwitchPlayerDelegate();

public class SwitchPlayer : MonoBehaviour
{
    static public bool _switchPlayer;    
    [SerializeField] private GameObject _cross;
    [SerializeField] private GameObject _no;
    public Vector2 CurMousePos;

    private void Start()
    {
        DecideWhoGoes();
    }

    public void Update()
    {
        SelectBox();
    }

    private void DecideWhoGoes()
    {
        int temp = Random.Range(0, 2);
        if (temp == 0)
        {
            _switchPlayer = false;
            StepCross();
        }
        if (temp == 1)
        {
            _switchPlayer = true;
            StepNo();
        }        
    }
    public void StepCross()
    {
        _cross.SetActive(true);
        _no.SetActive(false);
    }
    public void StepNo()
    {
        _cross.SetActive(false);
        _no.SetActive(true);
    }
    public void ChangeStatusSwitchPlayer()
    {
        if (_switchPlayer == true)
        {
            _switchPlayer = false;
        }
        if (_switchPlayer == false)
        {
            _switchPlayer = true;
        }
    }

    public void SelectBox()
    {
        CurMousePos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D rayHit = Physics2D.Raycast(CurMousePos,Vector2.zero);
            if (rayHit.collider != null)
            {
                Debug.Log("Selected object: " + rayHit.collider.tag);
            }
                
        }
    }
    

}
