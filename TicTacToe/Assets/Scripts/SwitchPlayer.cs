using UnityEngine;

public delegate void SwitchPlayerDelegate();


public class SwitchPlayer : MonoBehaviour
{
    public static SwitchPlayerDelegate switchPlayer;
    
    static public bool _switchPlayer;    
    [SerializeField] private GameObject _cross;
    [SerializeField] private GameObject _no;
    

    private void Start()
    {
        DecideWhoGoes();
        switchPlayer = ChangeStatusSwitchPlayer;        
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
        else
        {
            _switchPlayer = true;
        }
    }
   
}
