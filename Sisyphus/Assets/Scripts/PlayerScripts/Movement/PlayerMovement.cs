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
    public int PlayerLevel;
    public float PlayerHealth;

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    private void Start()
    {
        currentState = PlayerStates.NotTalking;
        LoadPlayer();
    }

    private void Update()
    {
        SavePlayer();
    }

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

    //Saves and loads player data
    #region PlayerData

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        PlayerLevel = data.level;
        PlayerHealth = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

    #endregion
}
