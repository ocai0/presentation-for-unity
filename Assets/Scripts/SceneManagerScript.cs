using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : MonoBehaviour {
    public static SceneManagerScript instance;
    public string mode = "SLIDE";
    private int sceneIndex = 0;
    void Awake() {
        Debug.Log("SceneManager.loadedSceneCount: " + SceneManager.sceneCount);
        if(instance != null && instance != this) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        // DontDestroyOnLoad(gameObject);
    }
    void Update() {
        if(mode == "SLIDE") {
            if(Input.GetKeyDown(KeyCode.RightArrow)) {
                NextScene();
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow)) {
                PreviousScene();
            }
            if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) {
                mode = "GAME";
            }
        }
        else {
            if(Input.GetKeyDown(KeyCode.Escape)) {
                mode = "SLIDE";
            }
        }
    }
    void NextScene() {
        StopAllCoroutines();
        goToScene(this.sceneIndex + 1);
    }
    void PreviousScene() {
        StopAllCoroutines();
        goToScene(this.sceneIndex - 1);
    }
    private void goToScene(int index) {
        if(index < 0) index = 0;
        if(index > 1) index = 1;

        Debug.Log("ScenePath: '" + "Assets/Scenes/Slide " + index + "'");
        Scene nextScene = SceneManager.GetSceneByPath("Assets/Scenes/Slide " + index);
        Debug.Log(nextScene.name);
        if(nextScene.isValid()) Debug.Log("Scene is valid");

        // try {
        //     SceneManager.LoadScene(this.SLIDES[index]);
        //     this.sceneIndex = index;
        // }
        // catch(System.Exception e) {
        //     Debug.Log(e.Message);
        // }
    }
}
