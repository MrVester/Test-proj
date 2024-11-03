using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneController : MonoInstaller
{
    public float duration=2f;
    public string sceneNameToLoad;
    
    async void Awake()
    {   if(SceneManager.GetActiveScene().name!=sceneNameToLoad)
        await Task.Delay((int)(duration*1000));
        SceneManager.LoadSceneAsync(sceneNameToLoad,LoadSceneMode.Single);
    }
}
