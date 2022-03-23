using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderInteraction : MonoBehaviour, IDamage {
    [SerializeField] private float _moveSpeed;

    private Vector3 startPosition;
    private Vector3 positionHolder;
    private Vector3 endPosition;
    private bool canMove;
    private bool canReturnToStart;

    private void Start() {
        startPosition = transform.position;
        endPosition = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
        positionHolder = endPosition;
    }
    private void Update() {
        float step = _moveSpeed * Time.deltaTime;
        if (canMove && !canReturnToStart) {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, step);
        }
        else if(canReturnToStart){
            transform.position = Vector3.MoveTowards(transform.position, endPosition, step);
            if(transform.position.Equals(startPosition)){
                endPosition = positionHolder;
                canReturnToStart = false;
                canMove = false;
            }
        }
        if (transform.position.Equals(endPosition)) {
            canReturnToStart = true;
            endPosition = startPosition;
        }
    }
    public void TakeDamage() {
        canMove = true;
    }
}
