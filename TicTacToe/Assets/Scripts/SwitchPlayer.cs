using UnityEngine;

public class SwitchPlayer : MonoBehaviour
{
    [SerializeField] private bool _switchPlayer;
    [SerializeField] private GameObject[] _ticToe;


    private void Start()
    {
        int temp = Random.Range(0,2);
        if (temp == 0 ) _switchPlayer = true;
        else _switchPlayer = false;
    }   

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ActivatorTicTacToe ac = GetComponent<ActivatorTicTacToe>();
            if(ac == null )
            {
                print("все пошло не по плану");
            }
            else print("не сработало");
            ac.ActiveTicToe(_switchPlayer);
        }
        
    }
}
