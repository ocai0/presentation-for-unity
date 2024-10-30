using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : MonoBehaviour {
    public static SceneManagerScript instance;
    public string mode = "SLIDE";
    private int sceneIndex = 0;
    void Awake() {
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

        var ghostsInScene = FindObjectsOfType(typeof(Ghost));
        foreach(Ghost ghost in ghostsInScene) ghost.home.StopCoroutines();
        
        SceneManager.LoadScene(index);
        this.sceneIndex = index;
    }
}
