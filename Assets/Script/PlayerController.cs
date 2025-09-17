using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] TileWalkability walk;   // ← 장애물 타일맵 검사기

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

        // 1) 대각선 시도
        if (!walk.IsBlocked(next)) { rb.MovePosition(next); return; }

        // 2) X축만
        Vector2 nextX = rb.position + new Vector2(vel.x, 0f) * Time.fixedDeltaTime;
        if (!walk.IsBlocked(nextX)) { rb.MovePosition(nextX); return; }

        // 3) Y축만
        Vector2 nextY = rb.position + new Vector2(0f, vel.y) * Time.fixedDeltaTime;
        if (!walk.IsBlocked(nextY)) { rb.MovePosition(nextY); return; }
        // 둘 다 막히면 제자리
    }
}
