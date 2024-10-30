using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    public LayerMask obstacleLayer;
    public List<Vector2> avaiableDirections { get; private set; }
    private void Start() {
        this.avaiableDirections = new List<Vector2>();

        CheckAvaiableDirections(Vector2.up);
        CheckAvaiableDirections(Vector2.down);
        CheckAvaiableDirections(Vector2.left);
        CheckAvaiableDirections(Vector2.right);
    }

    private void CheckAvaiableDirections(Vector2 direction) {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * .5f, .0f, direction, 1.0f, this.obstacleLayer);
        if(hit.collider == null) this.avaiableDirections.Add(direction);
    }
}
