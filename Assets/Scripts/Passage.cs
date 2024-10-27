// TODO: Fazer uma flag que mostre que o objeto (pac ou fantasma) ja estão dentro de um tunel, pra poder fazer uma logica em que: quando forem teleportados para a connection, não ativem os eventos de start e exit da propria connection, senao fica em loop, ja que eles nascem dentro da connection, que tambem tem esses efeitos
using UnityEngine;

public class Passage : MonoBehaviour {
    public GameObject connection;
    private void OnTriggerEnter2D(Collider2D other) {
        // Ghost ghost = other.GetComponent<Ghost>();
        // if(ghost != null) {
        //     SlowDownGhost(ghost);
        //     return;
        // }

        Pacman pacman = other.GetComponent<Pacman>();
        if(pacman && pacman.movement.bypassConnectionEnterCheck) {
            pacman.movement.bypassConnectionEnterCheck = false;
            pacman.movement.bypassConnectionExitCheck = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        Pacman pacman = other.GetComponent<Pacman>();
        if(pacman && pacman.movement.bypassConnectionExitCheck) {
            pacman.movement.bypassConnectionExitCheck = false;
        }
        else {
            Vector2 connectionSize = this.connection.GetComponent<BoxCollider2D>().size;
            float directionXAxis = 0.0f, directionYAxis = 0.0f;
            if(pacman) {
                directionXAxis = pacman.movement.direction.x;
                directionYAxis = pacman.movement.direction.y;
                pacman.movement.bypassConnectionEnterCheck = true;
            }
            else {
                Ghost ghost = other.GetComponent<Ghost>();
                directionXAxis = ghost.movement.direction.x;
                directionYAxis = ghost.movement.direction.y;
            }
            Vector3 newPosition = other.transform.position;
            newPosition.x = this.connection.transform.position.x;
            newPosition.y = this.connection.transform.position.y - (connectionSize.y/2 * directionYAxis);

            other.transform.position = newPosition;
        }
    }

    private void SlowDownGhost(Ghost ghost) {}
}
