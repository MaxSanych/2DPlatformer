using UnityEngine;

public class GemPoint : MonoBehaviour
{
    public Vector3 Position { get; private set; }

    public bool IsUsed { get; private set; }

    public bool IsRespawn()
    {
        IsUsed = false;

        return IsUsed;
    }

    public bool IsUse()
    {
        IsUsed = true;

        return IsUsed;
    }
}
