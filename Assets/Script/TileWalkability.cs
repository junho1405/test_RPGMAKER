using UnityEngine;
using UnityEngine.Tilemaps;

public class TileWalkability : MonoBehaviour
{
    [SerializeField] Tilemap obstacleTM;   // 나무/물/울타리 올린 타일맵

    public bool IsBlocked(Vector3 worldPos)
    {
        var cell = obstacleTM.WorldToCell(worldPos);
        return obstacleTM.HasTile(cell);   // 그 칸에 타일이 있으면 막힘
    }
}
