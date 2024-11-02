using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : MonoBehaviour {
    public static SceneManagerScript instance;
    public string mode = "SLIDE";
    public int sceneIndex = 0;
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
                Pacman pacman = (Pacman) FindObjectOfType(typeof(Pacman));
                pacman.autopilot = false;
            }
        }
        else {
            if(Input.GetKeyDown(KeyCode.Escape)) {
                Pacman pacman = (Pacman) FindObjectOfType(typeof(Pacman));
                mode = "SLIDE";
                pacman.autopilot = true;
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
        if(index > SceneManager.sceneCountInBuildSettings - 1) index = SceneManager.sceneCountInBuildSettings -1;
        Debug.Log("SceneManager.sceneCountInBuildSettings: " + SceneManager.sceneCountInBuildSettings);
        Debug.Log("index: " + index);

        this.sceneIndex = index;
        var ghostsInScene = FindObjectsOfType(typeof(Ghost));
        foreach(Ghost ghost in ghostsInScene) ghost.home.StopCoroutines();
        
        SceneManager.LoadScene(index);
    }
}
