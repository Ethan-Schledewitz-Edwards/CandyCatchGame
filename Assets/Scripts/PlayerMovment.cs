using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [Header("Values")]
    private float currentMoveSpeed;
    [SerializeField] float _defaultMoveSpeed = 10f;
    [SerializeField] float _jumpForce = 550f;

    [Header("Input")]
    private float movementInput;
    private bool facingRight;

    [Header("Physics")]
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] LayerMask _platformLayers;
    [SerializeField] BoxCollider2D _collider;
    private bool grounded;

    private void Start()
    {
        currentMoveSpeed = _defaultMoveSpeed;
        InputManager.Init(this);
        InputManager.GameMode();
        facingRight = true;
    }

    private void FixedUpdate()
    {
        groundCheck();
        movement();
    }

    #region Input Methods
    //This method sets the current movement direction
    public void SetMovementDir(float dir)
    {
        movementInput = dir;

        if (movementInput != 0)
            checkDir(movementInput > 0);
    }
    #endregion

    public void StopMovement()
    {
        _rb.velocity = new Vector2();
        movementInput = 0;
    }

    //This movement system uses acceleration and deceleration to make things feel less clunky and stiff
    private void movement()
    {
        //Multiplied by Vector2.right means it wont affect y
        _rb.AddForce(movementInput * currentMoveSpeed * Vector2.right);
    }

    //Checks a box the width of the players collider for objects on the ground layer..
    private void groundCheck()
    {
        RaycastHit2D hit = Physics2D.CircleCast(_collider.bounds.center, 0.25f, Vector2.down, 0.75f, _platformLayers);
        grounded = hit;
    }

    //Checks the direction the player is currently facing vs the facingRight bool. The Flip method is called if they are different.
    private void checkDir(bool isFacingRight)
    {
        if (isFacingRight != facingRight)
            flip();
    }

    //Flips the player by inverting their scale
    private void flip()
    {
        //stores scale and flips the player along the x axis, 
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        facingRight = !facingRight;
    }
}

