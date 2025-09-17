using UnityEngine;
using UnityEngine.Tilemaps;

public class TileWalkability : MonoBehaviour
{
    [SerializeField] Tilemap obstacleTM;   // ����/��/��Ÿ�� �ø� Ÿ�ϸ�

    public bool IsBlocked(Vector3 worldPos)
    {
        var cell = obstacleTM.WorldToCell(worldPos);
        return obstacleTM.HasTile(cell);   // �� ĭ�� Ÿ���� ������ ����
    }
}
