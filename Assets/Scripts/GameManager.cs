using UnityEngine;

public class GameManager : MonoBehaviour {

    public Ghost[] ghosts;
    public Pacman pacman;
    public Transform pellets;
    public int score { get; private set; }
    public int lives { get; private set; }
    public int ghostMultiplier { get; private set; } = 1;
    void Start() {
        NewGame();
    }
    void Update() {
        if(this.lives <= 0 && Input.anyKeyDown) {
            NewGame();
        }
    }

    private void NewGame() {
        SetScore(0);
        SetLives(3);
        ResetScene();
    }

    private void ResetScene() {
        foreach(Transform pellet in this.pellets) {
            pellet.gameObject.SetActive(true);
        }

        ResetActors();
    }

    private void ResetActors() {
        ResetGhostMultiplier();
        for(int i = 0; i < this.ghosts.Length; i++) {
            this.ghosts[i].gameObject.SetActive(true);
        }

        this.pacman.gameObject.SetActive(true);
    }

    private void GameOver() {
        for(int i = 0; i < this.ghosts.Length; i++) {
            this.ghosts[i].gameObject.SetActive(false);
        }
 
        this.pacman.gameObject.SetActive(false);
    }

    private void SetScore(int score) {
        this.score = score;
    }

    private void SetLives(int lives) {
        this.lives = lives;
    }

    public void GhostEaten(Ghost ghost) {
        SetScore(this.score + (ghost.points * this.ghostMultiplier));
        this.ghostMultiplier++;
    }

    public void PacmanEaten() {
        this.pacman.gameObject.SetActive(false);
        SetLives(this.lives - 1);
        if(this.lives > 0) {
            Invoke(nameof(ResetActors), 3.0f);
        }
        else {
            GameOver();
        }
    }

    public void PelletEaten(Pellet pellet) {
        pellet.gameObject.SetActive(false);
        SetScore(this.score + pellet.points);
        if(!HasRemainingPellets()) {
            this.pacman.gameObject.SetActive(false);
            Invoke(nameof(ResetScene), 3.0f);
        }
    }
    public void PowerPelletEaten(PowerPellet pellet) {
        // change ghost state
        PelletEaten(pellet);
        CancelInvoke();
        Invoke(nameof(ResetGhostMultiplier), pellet.duration);
    }

    public bool HasRemainingPellets() {
        foreach(Transform pellet in this.pellets)
            if(pellet.gameObject.activeSelf) return true;
        return false;
    }

    private void ResetGhostMultiplier() {
        this.ghostMultiplier = 1;
    }
}
