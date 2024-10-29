using System.Collections;
using UnityEngine;

public class GhostHome : GhostBehavior {
    public Transform inside;
    public Transform outside;

    private void OnEnable() {
        StopAllCoroutines();
    }
    private void OnDisable() {
        StartCoroutine(ExitTransition());
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(this.enabled && collision.gameObject.layer == LayerMask.NameToLayer("Obstacle")) {
            this.ghost.movement.SetDirection(-this.ghost.movement.direction);
        }
    }

    private IEnumerator ExitTransition() {
        this.ghost.movement.SetDirection(Vector2.up, true);
        this.ghost.movement.rigidbody.isKinematic = true;
        this.ghost.movement.enabled = false;
        
        Vector3 position = this.transform.position;
        float duration = .5f;
        float timeElapsed = 0f;

        while(timeElapsed < duration) {
            Vector3 newPosition = Vector3.Lerp(position, this.inside.position, timeElapsed / duration);
            newPosition.z = position.z;
            this.ghost.transform.position = newPosition;
            timeElapsed+=Time.deltaTime;
            yield return null;
        }

        timeElapsed = 0.0f;

        while(timeElapsed < duration) {
            Vector3 newPosition = Vector3.Lerp(this.inside.position, this.outside.position, timeElapsed / duration);
            newPosition.z = position.z;
            this.ghost.transform.position = newPosition;
            timeElapsed+=Time.deltaTime;
            yield return null;
        }

        this.ghost.movement.SetDirection(new Vector2(Random.value < .5f ? -1.0f : 1.0f, 0.0f), true);
        this.ghost.movement.rigidbody.isKinematic = false;
        this.ghost.movement.enabled = true;
    }
    public void StopCoroutines() {
        StopAllCoroutines();
    }
}
