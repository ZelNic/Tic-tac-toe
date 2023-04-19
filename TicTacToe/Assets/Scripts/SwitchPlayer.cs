using UnityEngine;

public delegate void SwitchPlayerDelegate();

public class SwitchPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _crossSprite;
    [SerializeField] private GameObject _noSprite;
    

    private void Start()
    {
        DecideWhoGoes();
    }
    public void FixedUpdate()
    {
        ChangeStatusSwitchPlayer();
    }
    private void DecideWhoGoes()
    {
        int temp = Random.Range(0, 2);
        if (temp == 0)
        {
            Judge.Instance.whoStep = false;
            StepCross();
        }
        if (temp == 1)
        {
            Judge.Instance.whoStep = true;
            StepNo();
        }        
    }
    public void StepCross()
    {
        _crossSprite.SetActive(true);
        _noSprite.SetActive(false);
    }
    public void StepNo()
    {
        _crossSprite.SetActive(false);
        _noSprite.SetActive(true);
    }
    public void ChangeStatusSwitchPlayer()
    {
        if (Judge.Instance.whoStep == true)
        {
            StepNo();
            
        }
        if (!Judge.Instance.whoStep)
        {
            StepCross();
        }
    }    
}
