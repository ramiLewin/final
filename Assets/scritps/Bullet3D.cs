using UnityEngine;

public class Bullet3D: MonoBehaviour
{
    public float speed = 20f;
    private Vector3 direction;

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
