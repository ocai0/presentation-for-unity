using UnityEngine;

public class GhostFrightned : GhostBehavior {
    public SpriteRenderer body;
    public SpriteRenderer eyes;
    public SpriteRenderer blue;
    public SpriteRenderer white;
    public bool eaten { get; private set; }
    public override void Enable(float duration) {
        base.Enable(duration);
        this.body.enabled = false;
        this.eyes.enabled = false;
        this.blue.enabled = true;
        this.white.enabled = false;
        Invoke(nameof(Flash), duration / 2.0f);
    }
    public override void Disable() {
        base.Disable();
        this.body.enabled = true;
        this.eyes.enabled = true;
        this.blue.enabled = false;
        this.white.enabled = false;

    }

    private void Flash() {
        if(!this.eaten) {
            this.blue.enabled = false;
            this.white.enabled = true;
            this.white.GetComponent<AnimatedSprite>().Restart();
        }
    }
    private void OnEnable() {
        this.ghost.movement.speedMultiplier = .5f;
        this.eaten = false;
    }
    private void OnDisable() {
        this.ghost.movement.speedMultiplier = 1.0f;
        this.eaten = false;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Pacman")) {
            if(this.enabled) Eaten();
        }
    }
    private void Eaten() {
        this.eaten = true;
        Vector3 position = this.ghost.home.inside.position;
        position.z = this.ghost.transform.position.z;
        this.ghost.transform.position = position;

        this.ghost.home.Enable();

        this.body.enabled = false;
        this.eyes.enabled = true;
        this.blue.enabled = false;
        this.white.enabled = false;

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(!this.enabled) return;
        Node node = other.GetComponent<Node>();
        if(node == null) return;
        Vector2 direction = Vector2.zero;
        float maxDistance = float.MinValue;

        foreach(Vector2 avaiableDirection in node.avaiableDirections) {
            Vector3 newPosition = this.transform.position + new Vector3(avaiableDirection.x, avaiableDirection.y, 0.0f);
            float distance = (this.ghost.target.position - newPosition).sqrMagnitude;
            if(distance > maxDistance) {
                direction = avaiableDirection;
                maxDistance = distance;
            }
        }
        this.ghost.movement.SetDirection(direction);
    }
}
