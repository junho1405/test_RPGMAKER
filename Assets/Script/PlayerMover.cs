using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private Tilemap groundTM; // GroundTR > Tilemap (ÀÚ½Ä)
    [SerializeField] private Tilemap objectTM; // ObjectGR > Tilemap (ÀÚ½Ä)
    [SerializeField] private TileBase waterTile;

    Rigidbody2D rb;
    Vector2 input;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    void Update()
    {
        input = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;
    }

    void FixedUpdate()
    {
        if (input.sqrMagnitude == 0f) return;

        Vector2 next = rb.position + input * moveSpeed * Time.fixedDeltaTime;
        if (IsWalkable(next))
            rb.MovePosition(next);
    }

    bool IsWalkable(Vector3 worldPos)
    {
        if (!groundTM) return true;

        Vector3Int cell = groundTM.WorldToCell(worldPos);

        if (objectTM && objectTM.HasTile(cell)) return false; // ¿ÀºêÁ§Æ® ¸·Èû
        var t = groundTM.GetTile(cell);
        if (t == null) return false;                           // ºóÄ­ ¸·Èû
        if (waterTile && t == waterTile) return false;         // ¹° ¸·Èû

        return true;
    }
}
