﻿using System.Collections.Generic;
using Gameplay.Core;
using UnityEngine;
using Utils;

namespace Gameplay.Behaviours
{
    public delegate void CollisionCallback(GameObject target);

    public class ColliderBehaviour : MonoBehaviour
    {
        readonly IDictionary<Team, List<Entity>> _collidingObjects = new Dictionary<Team, List<Entity>>();

        public event CollisionCallback OnAddCollider;

        public event CollisionCallback OnRemoveCollider;

        public List<Entity> GetCollidingObjects(Team team)
        {
            return _collidingObjects[team];
        }

        void Awake()
        {
            foreach (var team in Extensions.GetEnumValues<Team>())
            {
                _collidingObjects.Add(team, new List<Entity>());
            }
        }

        void OnCollisionEnter(Collision collision) => OnEnter(collision.collider);

        void OnCollisionExit(Collision collision) => OnExit(collision.collider);

        void OnTriggerEnter(Collider other) => OnEnter(other);

        void OnTriggerExit(Collider other) => OnExit(other);

        void OnEnter(Collider c)
        {
            var collidingObject = c.gameObject;
            AddObject(collidingObject);
        }

        void OnExit(Collider c)
        {
            var collidingObject = c.gameObject;
            RemoveObject(collidingObject);
        }

        void AddObject(GameObject collidingObject)
        {
            var entity = collidingObject.GetComponent<Entity>();
            if (entity == null)
            {
                return;
            }
            _collidingObjects[entity.Team].Add(entity);
            OnAddCollider?.Invoke(collidingObject);
            entity.OnRemoved += RemoveObject;
        }

        void RemoveObject(GameObject collidingObject)
        {
            var entity = collidingObject.GetComponent<Entity>();
            if (entity == null)
            {
                return;
            }
            _collidingObjects[entity.Team].Remove(entity);
            OnRemoveCollider?.Invoke(collidingObject);
            entity.OnRemoved -= RemoveObject;
        }

        // This way we enforce that a gameObject will trigger OnRemoveCollider even if it gets destroyed
        void RemoveObject(Entity entity) => RemoveObject(entity.gameObject);
    }
}
