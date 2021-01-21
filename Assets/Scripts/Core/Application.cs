using System.Collections;
using AMVC.Systems;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AMVC.Core
{
    public class Application : MonoBehaviour
    {
        private static Application _instance;

    public AppModel models;
    public AppView views;
    public AppController controllers;
    
    
    public bool run;
    
    private void Awake()
    {
        if (_instance != null)
        {
            GameObject.Destroy(this.gameObject);
            return;
        }
        _instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        Initialize();
        StartLoading();
    }

    private void StartLoading()
    {
        var loadingSystem = GetSystem<LoadingSystem>();
        loadingSystem.OnComplete += model => this.models = model;
        loadingSystem.StartLoading();
    }
    
    public void LoadScene(string sceneName)
    {
        StopCoroutine(Tick());
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        
        var operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            yield return null;
        }
        print("Load Scene Complete");
        views = AppScene.appView;
        controllers = AppScene.appController;
        Initialize();
        StartApp();
    }
    
    private void Initialize()
    {
        //models = new PlayerModel();
        //models.Initialize(this);
        controllers.Initialize(this);
        views.Initialize(this);
    }

    //[Button("Start Application", ButtonSizes.Large)]
    private void StartApp()
    {
        controllers.StartController();
        run = true;
        StartCoroutine(Tick());
    }
    
    //[Button("Pause Application", ButtonSizes.Large)]
    private void PauseApp()
    {
        StopCoroutine(Tick());
        run = false;
    }
    
    //[Button("Resume Application", ButtonSizes.Large)]
    private void ResumeApp()
    {
        run = true;
        StartCoroutine(Tick());
    }

    private IEnumerator Tick()
    {
        while (run)
        {
            print("Tick");
            controllers.Tick();
            views.Tick();
            yield return null;
        }
    }
    
    public T GetSystem<T>() where T : AppSystem
    {
        return controllers.GetSystem<T>();
    }

    public T GetPanel<T>() where T : AppPanel
    {
        return views.GetPanel<T>();
    }
    }
}
