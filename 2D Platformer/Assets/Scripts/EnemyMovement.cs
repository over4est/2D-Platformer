using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<EnemyWaypoint> _waypoints;
    [SerializeField] private float _touchDisatance;

    private SpriteFlipper _spriteFlipper;
    private Mover _mover;
    private int _currentWaypoint = 0;

    public float XMovementDirection { get; private set; }

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _spriteFlipper = GetComponentInChildren<SpriteFlipper>();
    }

    public void MoveToWaypoint()
    {
        float sqrDistanceToWaypoint = (_waypoints[_currentWaypoint].transform.position - transform.position).sqrMagnitude;

        if (sqrDistanceToWaypoint <= _touchDisatance)
        {
            _currentWaypoint = ++_currentWaypoint % _waypoints.Count;
        }

        XMovementDirection = (_waypoints[_currentWaypoint].transform.position - transform.position).normalized.x;

        _mover.Move(XMovementDirection);
        _spriteFlipper.TryFlip(XMovementDirection);
    }

    public void MoveToCharacter(Transform character)
    {
        XMovementDirection = (character.position - transform.position).normalized.x;

        _mover.Move(XMovementDirection);
        _spriteFlipper.TryFlip(XMovementDirection);
    }
}