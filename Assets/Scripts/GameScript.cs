using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    public GameObject circePrefab;
    public GameObject morganaPrefab;
    
    void Start()
    {
        var gamemode = ApplicationScript.Gamemode;
        var character = ApplicationScript.Character;
        
        var leftBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0, (transform.position - Camera.main.transform.position).z)
        ).x;
        
        if (gamemode == ApplicationScript.GamemodeEnum.SinglePlayer)
        {
            var playerPrefab = character == ApplicationScript.CharacterEnum.Circe ? circePrefab : morganaPrefab;
            var player = Instantiate(playerPrefab, new Vector3(leftBorder + 1, 0, 0), Quaternion.identity);
            var playerScript = player.GetComponent<PlayerScript>();
            playerScript.movementKeys = new[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
            playerScript.shootKey = KeyCode.Space;
        }
        else if (gamemode == ApplicationScript.GamemodeEnum.MultiPlayer)
        {
            Instantiate(circePrefab, new Vector3(leftBorder + 1, 1, 0), Quaternion.identity);
            Instantiate(morganaPrefab, new Vector3(leftBorder + 1, -1, 0), Quaternion.identity);
        }
    }

    private void OnDestroy()
    {
        SceneManager.LoadScene("Menu");
    }
}
