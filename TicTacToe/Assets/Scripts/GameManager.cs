using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Action onSetActiveFalse;
    public static Action<bool> onSetActiveTrue;
    public static Action onRestartGame;
    private void Awake()
    {
        Application.targetFrameRate = 120;
    }

    private void OnEnable()
    {
        onRestartGame += SubmitRequestForRestart;
    }

    public void SubmitRequestForRestart()
    {
        onSetActiveTrue?.Invoke(false);
        Invoke("ResetMainScene", 1f);       
    }

    public void ResetMainScene()
    {
        onSetActiveFalse?.Invoke();
        onSetActiveTrue?.Invoke(true);
    }

}
