using UnityEngine;
[RequireComponent(typeof(Movement))]
public class Pacman : MonoBehaviour {
    public Movement movement { get; private set; }
    private void Awake() {
        this.movement = GetComponent<Movement>();

    }
    private void Update() {
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

        float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x);
        this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }
}
