using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private string _gameLevelSceneName = "GameLevel";

    private Button _playButton;
    private Button _quitButton;

    private void Awake()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        _playButton = root.Q<Button>("PlayButton");
        _quitButton = root.Q<Button>("QuitButton");
    }

    private void OnEnable()
    {
        _playButton.RegisterCallback<ClickEvent>(OnPlayClicked);
        _quitButton.RegisterCallback<ClickEvent>(OnQuitClicked);
    }

    private void OnDisable()
    {
        _playButton.UnregisterCallback<ClickEvent>(OnPlayClicked);
        _quitButton.UnregisterCallback<ClickEvent>(OnQuitClicked);
    }

    private void OnPlayClicked(ClickEvent evt)
    {
        SceneManager.LoadScene(_gameLevelSceneName);
    }

    private void OnQuitClicked(ClickEvent evt)
    {
        Debug.Log("Quit");
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}