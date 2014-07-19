using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using Assets.Telekinesis.Scripts.Regular.Actions;
using Assets.Telekinesis.Scripts.Regular.Framework;
using NUnit.Framework;
using UnityEngine;
using NSubstitute;

namespace Assets.Telekinesis.Scripts.Editor.UnitTests.Actions
{
    public class MovementTest
    {
        GameObject _go { get; set; }

        private void CreateGameObject()
        {
            _go = new GameObject();
            _go.AddComponent<Rigidbody2D>();
            _go.AddComponent<Movement>();
        }

        [Test]
        public void Move_ShouldReturnPositiveXValue_WhenXValueIsPositiveAndHasRigidbody()
        {
            //Arrange
            CreateGameObject();
            var movementComponent = _go.GetComponent<Movement>();
            movementComponent.HasRigidBody = true;

            float num1 = 1;
            float num2 = 2;

            //Act
            movementComponent.Move(new Vector2(num1, num2));

            //Assert
            Assert.GreaterOrEqual(_go.rigidbody2D.velocity.x, 0);
        }

        [Test]
        public void Move_ShouldReturnNegativeXValue_WhenXValueIsNegativeAndHasRigidbody()
        {
            //Arrange
            CreateGameObject();
            var movementComponent = _go.GetComponent<Movement>();
            movementComponent.HasRigidBody = true;

            float num1 = -1;
            float num2 = 2;

            //Act
            movementComponent.Move(new Vector2(num1, num2));

            //Assert
            Assert.LessOrEqual(_go.rigidbody2D.velocity.x, 0);
        }

        [Test]
        public void Move_ShouldReturnPositiveYValue_WhenYValueIsPositiveAndHasRigidbody()
        {
            //Arrange
            CreateGameObject();
            var movementComponent = _go.GetComponent<Movement>();
            movementComponent.HasRigidBody = true;

            float num1 = 1;
            float num2 = 2;

            //Act
            movementComponent.Move(new Vector2(num1, num2));

            //Assert
            Assert.GreaterOrEqual(_go.rigidbody2D.velocity.y, 0);
        }

        [Test]
        public void Move_ShouldReturnNegativeYValue_WhenYValueIsNegativeAndHasRigidbody()
        {
            //Arrange
            CreateGameObject();
            var movementComponent = _go.GetComponent<Movement>();
            movementComponent.HasRigidBody = true;

            float num1 = 1;
            float num2 = -2;

            //Act
            movementComponent.Move(new Vector2(num1, num2));

            //Assert
            Assert.LessOrEqual(_go.rigidbody2D.velocity.y, 0);
        }

        [Test]
        public void Move_ShouldReturnZeroYValue_WhenNotHasVerticalMovementAndHasRigidbody()
        {
            //Arrange
            CreateGameObject();
            var movementComponent = _go.GetComponent<Movement>();
            movementComponent.HasRigidBody = true;
            movementComponent.HasVericalMovement = false;

            float num1 = 1;
            float num2 = 2;

            //Act
            movementComponent.Move(new Vector2(num1, num2));

            //Assert
            Assert.AreEqual(_go.rigidbody2D.velocity.y, 0);
        }

        [Test]
        public void Move_ShouldReturnPositiveXValue_WhenXValueIsPositiveAndNotHasRigidbody()
        {
            //Arrange
            CreateGameObject();
            var movementComponent = _go.GetComponent<Movement>();
            movementComponent.HasRigidBody = false;

            float num1 = 1;
            float num2 = 2;

            //Act
            movementComponent.Move(new Vector2(num1, num2));

            //Assert
            Assert.GreaterOrEqual(_go.transform.position.x, 0);
        }

        [Test]
        public void Move_ShouldReturnNegativeXValue_WhenXValueIsNegativeAndNotHasRigidbody()
        {
            //Arrange
            CreateGameObject();
            var movementComponent = _go.GetComponent<Movement>();
            movementComponent.HasRigidBody = false;

            float num1 = -1;
            float num2 = 2;

            //Act
            movementComponent.Move(new Vector2(num1, num2));

            //Assert
            Assert.LessOrEqual(_go.transform.position.x, 0);
        }

        [Test]
        public void Move_ShouldReturnPositiveYValue_WhenYValueIsPositiveAndNotHasRigidbody()
        {
            //Arrange
            CreateGameObject();
            var movementComponent = _go.GetComponent<Movement>();
            movementComponent.HasRigidBody = false;

            float num1 = 1;
            float num2 = 2;

            //Act
            movementComponent.Move(new Vector2(num1, num2));

            //Assert
            Assert.GreaterOrEqual(_go.transform.position.y, 0);
        }

        [Test]
        public void Move_ShouldReturnNegativeYValue_WhenYValueIsNegativeAndNotHasRigidbody()
        {
            //Arrange
            CreateGameObject();
            var movementComponent = _go.GetComponent<Movement>();
            movementComponent.HasRigidBody = true;

            float num1 = 1;
            float num2 = -2;

            //Act
            movementComponent.Move(new Vector2(num1, num2));

            //Assert
            Assert.LessOrEqual(_go.transform.position.y, 0);
        }

        [Test]
        public void Move_ShouldReturnZeroYValue_WhenNotHasVerticalMovementAndNotHasRigidbody()
        {
            //Arrange
            CreateGameObject();
            var movementComponent = _go.GetComponent<Movement>();
            movementComponent.HasRigidBody = true;
            movementComponent.HasVericalMovement = false;

            float num1 = 1;
            float num2 = 2;

            //Act
            movementComponent.Move(new Vector2(num1, num2));

            //Assert
            Assert.AreEqual(_go.transform.position.y, 0);
        }
    }
}
