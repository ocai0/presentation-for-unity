using UnityEngine;
[RequireComponent(typeof(Movement))]
public class Pacman : MonoBehaviour {
    public Movement movement { get; private set; }
    public bool autopilot = true;
    SceneManagerScript sceneManager;
    private void Awake() {
        this.movement = GetComponent<Movement>();
        this.sceneManager = (SceneManagerScript) FindObjectOfType(typeof(SceneManagerScript));
        if(this.sceneManager.mode == "GAME") {
            this.autopilot = true;
        }
    }
    private void Update() {
        if(!this.autopilot) {
            this.HandleUserInteration();
        }
        this.SetSpriteRotation();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(!this.autopilot) return;
        Node node = other.GetComponent<Node>();
        if(node == null) return;

        if(node.forcePacmanOnDirection.x != 0 || node.forcePacmanOnDirection.y != 0) {
            this.movement.SetDirection(node.forcePacmanOnDirection);
        }
        else {
            int index = Random.Range(0, node.avaiableDirections.Count - 1);
            if(node.avaiableDirections[index] == -this.movement.direction && node.avaiableDirections.Count > 1) {
                index++;
                if(index >= node.avaiableDirections.Count) index = 0;
            }
            this.movement.SetDirection(node.avaiableDirections[index]);
        }
    }
    private void HandleUserInteration() {
        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            this.movement.SetDirection(Vector2.up);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)) {
            this.movement.SetDirection(Vector2.down);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            this.movement.SetDirection(Vector2.left);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)) {
            this.movement.SetDirection(Vector2.right);
        }
    }
    private void SetSpriteRotation() {
        float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x);
        this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
        // if(this.autopilot) this.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(this.movement.nextDirection.y, this.movement.nextDirection.x) * Mathf.Rad2Deg, Vector3.forward);
    }
    public void ResetState() {
        this.gameObject.SetActive(true);
        this.movement.ResetState();
    }
}
