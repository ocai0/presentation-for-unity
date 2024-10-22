using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : MonoBehaviour {
    public static SceneManagerScript instance;
    void Awake() {
        if(instance != null && instance != this) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Update() {
        if(Input.GetKeyDown(KeyCode.N)) {
            Debug.Log("Next");
            NextScene();
        }
        if(Input.GetKeyDown(KeyCode.P)) {
            Debug.Log("Previous");
            PreviousScene();
        }
    }
    void NextScene() {
        if(SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1) != null)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void PreviousScene() {
        if(SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex - 1) != null)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
