using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    private void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
    
    public void PressSinglePlayer()
    {
        ApplicationScript.Gamemode = ApplicationScript.GamemodeEnum.SinglePlayer;
        ApplicationScript.Character = ApplicationScript.CharacterEnum.Morgana;
        StartGame();
    }
    
    public void PressMultiPlayer()
    {
        ApplicationScript.Gamemode = ApplicationScript.GamemodeEnum.MultiPlayer;
        StartGame();
    }
}
