using UnityEngine;

public class GhostScatter : GhostBehavior {
    private void OnDisable() {
        this.ghost.chase.Enable();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(!this.enabled || this.ghost.frightned.enabled) return;
        Node node = other.GetComponent<Node>();
        if(node == null) return;
        int index = Random.Range(0, node.avaiableDirections.Count - 1);

        if(node.avaiableDirections[index] == -this.ghost.movement.direction && node.avaiableDirections.Count > 1) {
            index++;
            if(index > node.avaiableDirections.Count) index = 0;
        }
        this.ghost.movement.SetDirection(node.avaiableDirections[index]);
    }
}
