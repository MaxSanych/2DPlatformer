using System.Collections;
using System.Drawing;
using UnityEngine;

[RequireComponent(typeof(Gem))]

public class GemGenerator : MonoBehaviour
{
    [SerializeField] private int _spawnTimeStep;

    [SerializeField] private Gem _gem;

    private GemPoint[] _points;

    private bool _isDelayComplieted = true;

    private void Awake()
    {
        _points = gameObject.GetComponentsInChildren<GemPoint>();
    }

    private void Update()
    {
        if (_isDelayComplieted)
        {
            _isDelayComplieted = false;

            if (AreAllPointsUsed())
                ResetSpawnPoints();

            CreateGem();

            StartCoroutine(ExecuteDelay());
        }
    }

    private void CreateGem()
    {
        foreach (GemPoint point in _points)
        {
            if (point.IsUsed == false)
            {
                Instantiate(_gem, point.transform.position, Quaternion.identity);
                point.IsUsed = true;
                break;
            }
        }
    }

    private bool AreAllPointsUsed()
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
    }

    private IEnumerator ExecuteDelay()
    {
        yield return new WaitForSeconds(_spawnTimeStep);
        _isDelayComplieted = true;
    }
}