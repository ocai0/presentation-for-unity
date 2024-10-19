using UnityEngine;

public class PowerPellet : Pellet {
    public float duration = 8.0f;
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    protected override void Eat() {
        FindObjectOfType<GameManager>().PowerPelletEaten(this);
    }
}
