using UnityEngine;

public class GemPoint : MonoBehaviour
{
    public int _gemTimeSpawnStep;
    public Vector3 Position { get; private set; }

    public bool IsUsed;

    public void CreateGem(Gem gem)
    {
        if (IsUsed)
        {
            return;
        }
        else
        {
            Instantiate(gem, transform.position, Quaternion.identity);
            IsUsed = true;
        }
    }
}
