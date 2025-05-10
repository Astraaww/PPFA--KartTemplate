using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Canvas menuCanvas;
    public Canvas gameCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        menuCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Time.timeScale = 0f;
            menuCanvas.enabled = true;
            gameCanvas.enabled = false;
        }

        if (menuCanvas.enabled == true && Input.GetKeyDown(KeyCode.Escape))
        {
            menuCanvas.enabled = false;
            gameCanvas.enabled = true;
            Time.timeScale = 1f;
        }
    }
}
