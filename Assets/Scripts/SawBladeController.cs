using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class SawBladeController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 10f;
    [Header("Collisions config")]
    public float rayLength = 0.1f;
    public float rayOffset = 0.1f;


    [SerializeField]private Vector2 _velocity;

    public Vector2 InitialDirection { set { _velocity = value; } }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;

        DrawRayGizmo(transform.up);
        DrawRayGizmo(transform.right);
        DrawRayGizmo(-transform.right);
        DrawRayGizmo(-transform.up);

    }

    private void DrawRayGizmo(Vector3 dir) {
        Vector3 from = transform.position + dir * rayOffset;
        Vector3 to = from + dir * rayLength;
        Gizmos.DrawLine(from, to);
    }

    private void Update() {
        CheckAllSideCollisions();
        transform.position += (Vector3)_velocity.normalized * moveSpeed * Time.deltaTime;
    }

    private void CheckAllSideCollisions() {
        bool right = _velocity.x >= 0 && CheckCollision(transform.right);
        bool left = _velocity.x <= 0 && CheckCollision(-transform.right);
        bool up = _velocity.y >= 0 && CheckCollision(transform.up);
        bool down = _velocity.y <= 0 && CheckCollision(-transform.up);
        
        if(left || right) {
            _velocity.x *= -1f;
        }

        if(up || down || (left && right)) {
            _velocity.y *= -1f; 
        }
    }

    private bool CheckCollision(Vector3 dir) {
        Vector3 from = transform.position + dir * rayOffset;
        RaycastHit2D hit = Physics2D.Raycast(from, dir, rayLength);

        if(hit.transform == null || hit.transform == transform) {
            return false;
        }

        if (hit.transform.CompareTag("Player")) {
            //TODO: Player damage implementation
        }

        if (hit.transform.CompareTag("DeSpawner")) {
            gameObject.SetActive(false);
        }

        return true;
    }

}
