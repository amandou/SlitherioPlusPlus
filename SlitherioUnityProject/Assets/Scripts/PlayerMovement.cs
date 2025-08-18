using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float moveSpeed = 1.0f;
    
    private bool _canMove;

    private void Start()
    {
        _canMove = true;
    }

    private void FixedUpdate()
    {
        if (!_canMove) return;
        
        var horizontalMovement = Input.GetAxis("Horizontal");
        var verticalMovement = Input.GetAxis("Vertical");
        
        var move = new Vector3(horizontalMovement, verticalMovement, 0f) * (moveSpeed * Time.fixedDeltaTime);
        _rigidbody.MovePosition(_rigidbody.position + move);
    }
    
    public void StopPlayerMovement()
    {
        _canMove = false;
    }
}
