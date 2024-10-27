// TODO: Fazer uma flag que mostre que o objeto (pac ou fantasma) ja estão dentro de um tunel, pra poder fazer uma logica em que: quando forem teleportados para a connection, não ativem os eventos de start e exit da propria connection, senao fica em loop, ja que eles nascem dentro da connection, que tambem tem esses efeitos
using UnityEngine;

public class Passage : MonoBehaviour {
    public GameObject connection;
    private void OnTriggerEnter2D(Collider2D other) {
        Ghost ghost = other.GetComponent<Ghost>();
        if(ghost && ghost.movement.bypassConnectionEnterCheck) {
            ghost.movement.bypassConnectionEnterCheck = false;
            ghost.movement.bypassConnectionExitCheck = true;
        }

        Pacman pacman = other.GetComponent<Pacman>();
        if(pacman && pacman.movement.bypassConnectionEnterCheck) {
            pacman.movement.bypassConnectionEnterCheck = false;
            pacman.movement.bypassConnectionExitCheck = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        Pacman pacman = other.GetComponent<Pacman>();
        if(pacman) {
            if(pacman.movement.bypassConnectionExitCheck) {
                pacman.movement.bypassConnectionExitCheck = false;
            }
            else {
                Vector2 connectionSize = this.connection.GetComponent<BoxCollider2D>().size;
                float directionXAxis = pacman.movement.direction.x;
                float directionYAxis = pacman.movement.direction.y;
                
                pacman.movement.bypassConnectionEnterCheck = true;

                Vector3 newPosition = other.transform.position;
                newPosition.x = this.connection.transform.position.x;
                newPosition.y = this.connection.transform.position.y - (connectionSize.y/2 * directionYAxis);

                other.transform.position = newPosition;
            }
        }
        Ghost ghost = other.GetComponent<Ghost>();
        if(ghost) {
            if(ghost.movement.bypassConnectionExitCheck) {
                ghost.movement.bypassConnectionExitCheck = false;
            }
            else {
                Vector2 connectionSize = this.connection.GetComponent<BoxCollider2D>().size;
                float directionXAxis = ghost.movement.direction.x;
                float directionYAxis = ghost.movement.direction.y;
                
                ghost.movement.bypassConnectionEnterCheck = true;

                Vector3 newPosition = other.transform.position;
                newPosition.x = this.connection.transform.position.x;
                newPosition.y = this.connection.transform.position.y - (connectionSize.y/2 * directionYAxis);

                other.transform.position = newPosition;
            }
        }
    }

    private void SlowDownGhost(Ghost ghost) {}
}
