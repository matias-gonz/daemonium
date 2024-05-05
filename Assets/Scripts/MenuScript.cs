using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject characterSelectionMenu;
    public GameObject multiplayerMenu;
    
    private void Start()
    {
        mainMenu.gameObject.SetActive(true);
        characterSelectionMenu.gameObject.SetActive(false);
        multiplayerMenu.gameObject.SetActive(false);
    }
    
    private void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
    
    public void PressSinglePlayer()
    {
        SoundScript.Instance.PlayUIClickSound();
        ApplicationScript.Gamemode = ApplicationScript.GamemodeEnum.SinglePlayer;
        ApplicationScript.Character = ApplicationScript.CharacterEnum.Morgana;
        mainMenu.gameObject.SetActive(false);
        characterSelectionMenu.gameObject.SetActive(true);
    }
    
    public void PressMultiPlayer()
    {
        SoundScript.Instance.PlayUIClickSound();
        ApplicationScript.Gamemode = ApplicationScript.GamemodeEnum.MultiPlayer;
        mainMenu.gameObject.SetActive(false);
        multiplayerMenu.gameObject.SetActive(true);
        Invoke(nameof(StartGame), 1);
    }
    
    public void PressCirce()
    {
        SoundScript.Instance.PlayUIClickSound();
        ApplicationScript.Character = ApplicationScript.CharacterEnum.Circe;
        StartGame();
    }
    
    public void PressMorgana()
    {
        SoundScript.Instance.PlayUIClickSound();
        ApplicationScript.Character = ApplicationScript.CharacterEnum.Morgana;
        StartGame();
    }
}
