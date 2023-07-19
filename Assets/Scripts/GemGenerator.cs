using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Gem))]

public class GemGenerator : MonoBehaviour
{
    [SerializeField] private int _spawnTimeStep;

    [SerializeField] private Gem _gem;

    private GemPoint[] _points;

    private float _runningTime;

    private void Awake()
    {
        int spawnTime = 0;

        _points = gameObject.GetComponentsInChildren<GemPoint>();

        foreach (GemPoint point in _points)
        {
            spawnTime += _spawnTimeStep;
            point._gemTimeSpawnStep = spawnTime;
        }

        StartCoroutine(CreateGem());
    }

    private bool CheckAllPointsForUse()
    {
        foreach (GemPoint point in _points)
        {
            if (point.IsUsed == false)
            {
                return false;
            }
        }

        return true;
    }

    private void ResetSpawnPoints()
    {
        foreach (GemPoint point in _points)
        {
            point.IsUsed = false;
        }

        _runningTime = 0;
    }

    private IEnumerator CreateGem()
    {
        while (true)
        {
            _runningTime += Time.deltaTime;

            foreach (GemPoint point in _points)
            {
                if (point._gemTimeSpawnStep - _runningTime < 0)
                {
                    point.CreateGem(_gem);
                }

                if (CheckAllPointsForUse())
                {
                    ResetSpawnPoints();
                }
            }

            yield return null;
        }
    }
}