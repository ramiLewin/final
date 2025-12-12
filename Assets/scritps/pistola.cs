using UnityEngine;

public class pistola : MonoBehaviour
{
    public Transform gun;              // hijo que actúa como pistola
    public float sideX = 0.5f;         // distancia a la derecha (+X)
    private float lastDirection = 1f;  // 1 = derecha, -1 = izquierda

    void Update()
    {
        // Detectar dirección simple con teclas
        float dir = 0f;

        if (UnityEngine.InputSystem.Keyboard.current.rightArrowKey.isPressed)
            dir = 1f;
        else if (UnityEngine.InputSystem.Keyboard.current.leftArrowKey.isPressed)
            dir = -1f;

        if (dir != 0f && dir != lastDirection)
        {
            // Cambiar lado reflejando la X
            gun.localPosition = new Vector3(sideX * dir, gun.localPosition.y, gun.localPosition.z);

            // Guardar nueva dirección
            lastDirection = dir;
        }
    }
}
