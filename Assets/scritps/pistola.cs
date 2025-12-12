using UnityEngine;

public class pistola : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzle;

    public Transform posDerecha;   // empty a la derecha del player
    public Transform posIzquierda; // empty a la izquierda del player

    private bool mirandoDerecha = true;

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");

        // detectar cambio de dirección
        if (inputX > 0 && !mirandoDerecha)
        {
            mirandoDerecha = true;
            CambiarLado();
        }
        else if (inputX < 0 && mirandoDerecha)
        {
            mirandoDerecha = false;
            CambiarLado();
        }

        // disparo con Z
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Shoot();
        }
    }

    void CambiarLado()
    {
        if (mirandoDerecha)
        {
            transform.position = posDerecha.position;
            transform.rotation = posDerecha.rotation;
        }
        else
        {
            transform.position = posIzquierda.position;
            transform.rotation = posIzquierda.rotation;
        }
    }

    void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);
        Bullet3D bullet = bulletObj.GetComponent<Bullet3D>();

        Vector3 dir = mirandoDerecha ? Vector3.right : Vector3.left;
        bullet.SetDirection(dir);
    }

}
