using UnityEngine;

public class PauseGame : MonoBehaviour 
{
    public CameraFollow cameraFollow;
    public void Pause()
    {
        Time.timeScale = 0f;
        cameraFollow.enabled = false;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        cameraFollow.enabled = true;
    }
}
