using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class SceneController
{
    private float _duration;
    private string _sceneNameToLoad;

    public SceneController(float duration, string sceneName)
    {
        _duration = duration;
        _sceneNameToLoad = sceneName;
    }

    public void Init() 
    {
        LoadGameplayScene();
    }

    private async Task LoadGameplayScene() 
    {
        if(SceneManager.GetActiveScene().name != _sceneNameToLoad) 
        {
            await Task.Delay((int)(_duration * 1000));
            SceneManager.LoadScene(_sceneNameToLoad);
        }
    }
}
