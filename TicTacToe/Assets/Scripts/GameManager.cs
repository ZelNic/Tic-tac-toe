using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 120;
    }

    public void SubmitRequestForRestart()
    {
        Invoke("ResetMainScene", 1f);
    }

    public void ResetMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

}
