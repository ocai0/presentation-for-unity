using UnityEngine;

public class GhostChase : GhostBehavior {
    private void OnDisable() {
        this.ghost.scatter.Enable();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(!this.enabled && this.ghost.frightned.enabled) return;
        Node node = other.GetComponent<Node>();
        if(node == null) return;
        Vector2 direction = Vector2.zero;
        float minDistance = float.MaxValue;

        foreach(Vector2 avaiableDirection in node.avaiableDirections) {
            Vector3 newPosition = this.transform.position + new Vector3(avaiableDirection.x, avaiableDirection.y, 0.0f);
            float distance = (this.ghost.target.position - newPosition).sqrMagnitude;
            if(distance < minDistance) {
                direction = avaiableDirection;
                minDistance = distance;
            }
        }
        this.ghost.movement.SetDirection(direction);
    }
}
