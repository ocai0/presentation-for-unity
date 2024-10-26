using UnityEngine;

[RequireComponent(typeof(Ghost))]
public abstract class GhostBehaviour : MonoBehavior {
    public Ghost ghost { get; private set; }
    public float duration;
    private void Awake() {
        this.ghost = GetComponent<Ghost>();
        this.enabled = false;
    }
    public void Enable() {
        EnableDuration(this.duration);
    }
    public virtual void Enable(float duration) {
        this.enabled = true;
        CancelInvoke();
        Invoke(nameof(Disable), duration);
    }
    public virtual void Disable() {
        this.enabled = false;
        CancelInvoke();
    }
}
