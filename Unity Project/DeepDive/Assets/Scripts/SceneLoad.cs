using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// SceneLoad class.
/// Class contains methods to operate with scenes in Unity.
/// </summary>
public class SceneLoad : MonoBehaviour
{
    /// <summary>
    /// Method for cheking if Player object collided with gameWin object.
    /// </summary>
    /// <param name="other">Collider component.</param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            SceneManager.LoadScene("WinScreen", LoadSceneMode.Single);
        }
    }

    /// <summary>
    /// Method starts <see cref="LoadGame"/> coroutine.
    /// </summary>
    public void StartGame()
    {
        StartCoroutine(LoadGame());

    }

    /// <summary>
    /// Coroutine which starts to load Game Scene while being in Main Menu.
    /// </summary>
    IEnumerator LoadGame()
    {
        AsyncOperation GameLevel = SceneManager.LoadSceneAsync("GameScene");
        
        yield return new WaitUntil(() => GameLevel.isDone == true);
    }

    /// <summary>
    /// Method which loads Main Menu.
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    /// <summary>
    /// Method for exiting application.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    
}
