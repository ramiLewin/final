using UnityEngine;
using UnityEngine.InputSystem; // necesario para el nuevo sistema

public class playerMov : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 8f;
    public float gravity = -20f;

    private CharacterController cc;
    private float verticalVelocity = 0f;

    void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (cc == null) return;

        // Bloquear rotación SIEMPRE
        transform.rotation = Quaternion.identity;

        // Movimiento lateral
        float moveX = 0f;
        if (Keyboard.current.rightArrowKey.isPressed) moveX = 1f;
        else if (Keyboard.current.leftArrowKey.isPressed) moveX = -1f;

        // Saltar
        if (cc.isGrounded)
        {
            verticalVelocity = -1f;

            if (Keyboard.current.upArrowKey.wasPressedThisFrame)
                verticalVelocity = jumpForce;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        Vector3 move = new Vector3(moveX * speed, verticalVelocity, 0f);
        cc.Move(move * Time.deltaTime);
    }


}
