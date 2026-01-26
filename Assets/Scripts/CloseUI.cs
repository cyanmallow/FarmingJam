using UnityEngine;

public class CloseUI : MonoBehaviour
{
    [SerializeField] private GameObject cropSelectionUI;
    [SerializeField] private PauseGame pauseGame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnClick()
    {

        cropSelectionUI.SetActive(false);
        pauseGame.Resume();
    }

}
