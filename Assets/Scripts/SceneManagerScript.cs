using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : MonoBehaviour {
    public static SceneManagerScript instance;
    public string mode = "GAME";
    void Awake() {
        if(instance != null && instance != this) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Update() {
        if(mode == "SLIDE") {
            if(Input.GetKeyDown(KeyCode.RightArrow)) {
                Debug.Log("Next");
                NextScene();
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow)) {
                Debug.Log("Previous");
                PreviousScene();
            }
            if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) {
                Debug.Log("Exit Slide Mode");
                mode = "GAME";
            }
        }
        else {
            if(Input.GetKeyDown(KeyCode.Escape)) {
                Debug.Log("Exit Game Mode");
                mode = "SLIDE";
            }
        }
    }
    void NextScene() {
        Debug.Log(SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1));
        if(SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1) != null)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void PreviousScene() {
        if(SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex - 1) != null)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
