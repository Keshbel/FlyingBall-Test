using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody2D _ballRigidbody;

    private void Start()
    {
        if (!_ballRigidbody) _ballRigidbody = GetComponent<Rigidbody2D>();
        
        speed = GameManager.HardMode * 3;
        jumpForce = GameManager.HardMode * 3;
        _ballRigidbody.gravityScale = GameManager.HardMode;

        StartCoroutine(ChangeVerticalMovementRoutine());
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            _ballRigidbody.velocity = Vector2.up * jumpForce;
        }
    }

    private IEnumerator ChangeVerticalMovementRoutine()
    {
        var time = 15f;
        
        while (this)
        {
            Invoke(nameof(ChangeVerticalMovement), time);
            yield return new WaitForSeconds(time);
        }
    }

    private void ChangeVerticalMovement()
    {
        if (!this) return;
        
        var updateValue = GameManager.Instance.verticalMovementUpgradeValue;
        jumpForce *= updateValue;
        _ballRigidbody.gravityScale *= updateValue;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameManager.Instance.EndGame();
    }
}
