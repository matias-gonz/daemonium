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
        ApplicationScript.Gamemode = ApplicationScript.GamemodeEnum.SinglePlayer;
        ApplicationScript.Character = ApplicationScript.CharacterEnum.Morgana;
        mainMenu.gameObject.SetActive(false);
        characterSelectionMenu.gameObject.SetActive(true);
    }
    
    public void PressMultiPlayer()
    {
        ApplicationScript.Gamemode = ApplicationScript.GamemodeEnum.MultiPlayer;
        mainMenu.gameObject.SetActive(false);
        multiplayerMenu.gameObject.SetActive(true);
        Invoke(nameof(StartGame), 1);
    }
    
    public void PressCirce()
    {
        ApplicationScript.Character = ApplicationScript.CharacterEnum.Circe;
        StartGame();
    }
    
    public void PressMorgana()
    {
        ApplicationScript.Character = ApplicationScript.CharacterEnum.Morgana;
        StartGame();
    }
}
