using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Enums
    public enum PlayerStates
    {
        Talking,
        NotTalking
    }
    public static PlayerStates currentState;
    #endregion

    #region Private variables
    Rigidbody2D rb;
    Vector2 movement;
    #endregion

    [Header("Values")]
    public float PlayerSpeed;

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    private void Start() => currentState = PlayerStates.NotTalking;

    // Update is called once per frame
    void FixedUpdate()
    {
        #region PlayerMovement
        movement = Vector2.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(movement != Vector2.zero)
        {
            MovePlayer();
        }
        #endregion
    }
    
    void MovePlayer() => rb.MovePosition(rb.position + movement.normalized * PlayerSpeed * Time.fixedDeltaTime);
}
