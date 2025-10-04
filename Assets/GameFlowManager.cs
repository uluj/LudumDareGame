using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System;
using UnityEngine.SceneManagement;


public class GameFlowManager : MonoBehaviour
{
    public enum GameStates { Start, Game, Win, Lose }
    [SerializeField] string StartScene = "Start";
    [SerializeField] string GameScene = "Game";
    [SerializeField] string WinScene = "Win";
    [SerializeField] string LoseScene = "Lose";


    string CurrentScene;
    string _currentLoaded;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(Boot());
    }
    IEnumerator Boot()
    {
        yield return TransitionTo(GameStates.Start);
    }

    public IEnumerator TransitionTo(GameStates Target)
    {
        string next = SceneName(Target);
        var LoadOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(next, LoadSceneMode.Additive);
        while (!LoadOperation.isDone) yield return null;
        var loaded = SceneManager.GetSceneByName(next);

        SceneManager.SetActiveScene(loaded);
        if (!string.IsNullOrEmpty(_currentLoaded) && _currentLoaded != next)
        {
            var unloadOp = SceneManager.UnloadSceneAsync(_currentLoaded);
            while (unloadOp != null && !unloadOp.isDone) yield return null;
        }
        _currentLoaded = next;


    }

    string SceneName(GameStates s) => s switch
    {
        GameStates.Start => StartScene,
        GameStates.Game => GameScene,
        GameStates.Win => WinScene,
        GameStates.Lose => LoseScene,
        _ => throw new ArgumentOutOfRangeException(nameof(s), s, "Unmapped GameStates")
    };

    public void GoToGame() { StartCoroutine(TransitionTo(GameStates.Game)); }
    public void GoToWin() { StartCoroutine(TransitionTo(GameStates.Win)); }
    public void GoToLose() { StartCoroutine(TransitionTo(GameStates.Lose)); }
    public void GoToStart() { StartCoroutine(TransitionTo(GameStates.Start)); }    
        
}
