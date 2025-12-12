using UnityEngine;
using UnityEngine.InputSystem; // necesario para el nuevo sistema

public class playerMov : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float move = 0f;

        if (Keyboard.current.rightArrowKey.isPressed)
            move = 1f;
        else if (Keyboard.current.leftArrowKey.isPressed)
            move = -1f;

        transform.position += new Vector3(move * speed * Time.deltaTime, 0f, 0f);
    }
}
