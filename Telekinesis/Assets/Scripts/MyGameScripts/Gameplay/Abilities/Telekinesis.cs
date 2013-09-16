using Assets.Scripts.MyGameScripts.Gameplay.Entities.Interfaces;
using Assets.Scripts.MyGenericScripts.Framework;
using Assets.Scripts.MyGenericScripts.Framework.Components;
using Assets.Scripts.MyGenericScripts.Framework.Entities;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.MyGameScripts.Gameplay.Abilities
{
    public class Telekinesis : Ability, ISelectionAbility
    {
        private float _horizontalPushStrength { get; set; }
        private float _verticalPushStrength { get; set; }
        private Rigidbody _targetRigidBody { get; set; }

        protected override void Start()
        {
            base.Start();

            _horizontalPushStrength = 100f;
            _verticalPushStrength = 75f;
        }

        private PhysicsEntity _target;

        public override Entity Target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = (PhysicsEntity)value;
                _targetRigidBody = value.rigidbody;
            }
        }

        public List<TEntity> GetSelection<TEntity>()
            where TEntity : Entity, ISelectable
        {
            var entityList = GameObjectManager.GetGameObjectsThatImplement<ISelectable>();
            return new List<TEntity>();
        }

        protected override void Invoke()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                _targetRigidBody.AddForce(new Vector3(0, _verticalPushStrength, 0));
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                _targetRigidBody.AddForce(new Vector3(-_horizontalPushStrength, 0, 0));
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                _targetRigidBody.AddForce(new Vector3(_horizontalPushStrength, 0, 0));
            }
        }
    }
}
