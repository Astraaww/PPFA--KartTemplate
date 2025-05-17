using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenWinScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter()
    {
        SceneManager.LoadScene("WinScene");
        Debug.Log("not player");
        
    }
}