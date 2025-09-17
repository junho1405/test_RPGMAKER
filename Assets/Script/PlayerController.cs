using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] TileWalkability walk;   // �� ��ֹ� Ÿ�ϸ� �˻��

    Rigidbody2D rb;
    Vector2 input;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    void Update()
    {
        input = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;
    }

    void FixedUpdate()
    {
        Vector2 vel = input * moveSpeed;
        Vector2 next = rb.position + vel * Time.fixedDeltaTime;

        // 1) �밢�� �õ�
        if (!walk.IsBlocked(next)) { rb.MovePosition(next); return; }

        // 2) X�ุ
        Vector2 nextX = rb.position + new Vector2(vel.x, 0f) * Time.fixedDeltaTime;
        if (!walk.IsBlocked(nextX)) { rb.MovePosition(nextX); return; }

        // 3) Y�ุ
        Vector2 nextY = rb.position + new Vector2(0f, vel.y) * Time.fixedDeltaTime;
        if (!walk.IsBlocked(nextY)) { rb.MovePosition(nextY); return; }
        // �� �� ������ ���ڸ�
    }
}
