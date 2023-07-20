using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Gem))]

public class GemGenerator : MonoBehaviour
{
    [SerializeField] private int _spawnTimeStep;

    [SerializeField] private Gem _gem;

    private GemPoint[] _points;

    private void Awake()
    {
        _points = gameObject.GetComponentsInChildren<GemPoint>();

        StartCoroutine(CreateGem());
    }

    private bool CheckAllPointsForUse()
    {
        foreach (GemPoint point in _points)
        {
            if (point.IsUsed == false)
                return false;
        }

        return true;
    }

    private void ResetSpawnPoints()
    {
        foreach (GemPoint point in _points)
            point.IsRespawn();
    }

    public void CreateGem(Gem gem, GemPoint point)
    {
            Instantiate(gem, point.transform.position, Quaternion.identity);
            point.IsUse();
    }

    private IEnumerator CreateGem()
    {
        while (true)
        {
            foreach (GemPoint point in _points)
            {
                yield return new WaitForSeconds(_spawnTimeStep);

                if (point.IsUsed == false)
                    CreateGem(_gem, point);

                if (CheckAllPointsForUse())
                    ResetSpawnPoints();
            }
        }
    }
}