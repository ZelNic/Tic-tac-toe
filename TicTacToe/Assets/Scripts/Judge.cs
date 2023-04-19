using System;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{

    public static Judge Instance;

    private string[] codeMove = { "147", "258", "369", "789", "456", "123", "357", "159" };


    //Dictionary <int,string> code = new Dictionary<int,string>();


    private List<string> moveLogCross = new List<string>();
    private string codeCrossLog;
    private List<string> moveLogNo = new List<string>();
    private string codeNoLog;

    private void Awake()
    {
        Instance = this;

        //CreateDictionary();
    }

    /*private void CreateDictionary()
    {
        for (int i = 0; i < codeMove.Length; i++)
        {
            code.Add(i, codeMove[i]);
        }
    }*/

    public void AddInListCross(string nameGO)
    {
        moveLogCross.Add(nameGO);
        codeCrossLog = null;
        for (int j = 0; j < moveLogCross.Count; j++) 
            codeCrossLog += moveLogCross[j];        
       
        print(codeCrossLog);
    }
    public void AddInListNo(string nameGO)
    {
        moveLogNo.Add(nameGO);
        codeNoLog = null;
        for (int j = 0; j < moveLogNo.Count; j++) 
            codeNoLog += moveLogNo[j];
        
        print(codeNoLog);
    }

    public void CheckWhoWinOrLose()
    {
        
    }
}
