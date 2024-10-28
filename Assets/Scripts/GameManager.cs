using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private List<Ghost> ghosts = new List<Ghost>();
    private Pacman pacman;
    private Transform pellets;
    public int score { get; private set; }
    public int lives { get; private set; }
    public int ghostMultiplier { get; private set; } = 1;
    
    private void Awake() {
        // Debug.Log("GameManager: Awake");
        var ghostsInScene = FindObjectsOfType(typeof(Ghost));
        foreach(Ghost ghost in ghostsInScene) this.ghosts.Add(ghost);
        this.pellets = GameObject.Find("/Grid/Pellets").GetComponent<Transform>();
        this.pacman = GameObject.Find("Pacman").GetComponent<Pacman>();
    }

    void Start() {
        // Debug.Log("GameManager: Start");
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
        for(int i = 0; i < this.ghosts.Count; i++) {
            if(this.ghosts[i]) this.ghosts[i].ResetState();
        }

        this.pacman.ResetState();
    }

    private void GameOver() {
        for(int i = 0; i < this.ghosts.Count; i++) {
            if(this.ghosts[i]) this.ghosts[i].gameObject.SetActive(false);
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
        for(int i = 0; i < this.ghosts.Count; i++) {
            if(this.ghosts[i]) this.ghosts[i].frightned.Enable(pellet.duration);
        }
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
