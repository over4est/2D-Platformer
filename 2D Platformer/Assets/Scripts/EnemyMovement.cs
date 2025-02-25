using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<EnemyWaypoint> _waypoints;
    [SerializeField] private float _touchDisatance;
    [SerializeField] private AnimatorController _animatorController;

    private Mover _mover;
    private int _currentWaypoint = 0;
    public float XDirection { get; private set; }

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    private void FixedUpdate()
    {
        float sqrDistanceToWaypoint = (_waypoints[_currentWaypoint].transform.position - transform.position).sqrMagnitude;

        if (sqrDistanceToWaypoint <= _touchDisatance)
        {
            _currentWaypoint = ++_currentWaypoint % _waypoints.Count;
        }

        XDirection = (_waypoints[_currentWaypoint].transform.position - transform.position).normalized.x;

        _mover.Move(XDirection);
        _animatorController.SetXDirectionValue(XDirection);
    }
}