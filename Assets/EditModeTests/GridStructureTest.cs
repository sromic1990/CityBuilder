using System;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class GridStructureTest
    {
        private GridStructure _structure;
        [OneTimeSetUp]
        public void Init()
        {
            _structure = new GridStructure(3, 100, 100);
        }
        
        #region GRID POSITION TESTS
        // A Test behaves as an ordinary method
        [Test]
        public void CalculateGridPositionPasses()
        {
            Vector3 position = new Vector3(0, 0, 0);
            //Act
            Vector3 returnPosition = _structure.CalculateGridPosition(position);
            //Assert
            Assert.AreEqual(Vector3.zero, returnPosition);
        }
        
        [Test]
        public void CalculateGridPositionFloatsPasses()
        {
            Vector3 position = new Vector3(2.9f, 0, 2.9f);
            //Act
            Vector3 returnPosition = _structure.CalculateGridPosition(position);
            //Assert
            Assert.AreEqual(Vector3.zero, returnPosition);
        }
        
        [Test]
        public void CalculateGridPositionFloatsFails()
        {
            //Arrange
            Vector3 position = new Vector3(3.1f, 0, 0f);
            //Act
            Vector3 returnPosition = _structure.CalculateGridPosition(position);
            //Assert
            Assert.AreNotEqual(Vector3.zero, returnPosition);
        }
        
        [Test]
        public void CalculateGridPositionNegativePasses()
        {
            Vector3 position = new Vector3(-1.9f, 0, -1.9f);
            //Act
            Vector3 returnPosition = _structure.CalculateGridPosition(position);
            //Assert
            Assert.AreEqual(Vector3.zero, returnPosition);
        }
        #endregion
        
        #region GRID PLACEMENTS TESTS

        [Test]
        public void PlaceStructure303AndCheckIsTakenPasses()
        {
            Vector3 position = new Vector3(3, 0, 3);
            //Act
            GameObject testGameObject = new GameObject("TestGameObject");
            _structure.PlaceStructureOnTheGrid(testGameObject, position);
            //Assert
            Assert.IsTrue(_structure.IsCellTaken(position));
        }
        
        [Test]
        public void PlaceStructureMINAndCheckIsTakenPasses()
        {
            Vector3 position = new Vector3(0, 0, 0);
            //Act
            GameObject testGameObject = new GameObject("TestGameObject");
            _structure.PlaceStructureOnTheGrid(testGameObject, position);
            //Assert
            Assert.IsTrue(_structure.IsCellTaken(position));
        }
        
        [Test]
        public void PlaceStructureMAXAndCheckIsTakenPasses()
        {
            Vector3 position = new Vector3(297, 0, 297);
            //Act
            GameObject testGameObject = new GameObject("TestGameObject");
            _structure.PlaceStructureOnTheGrid(testGameObject, position);
            //Assert
            Assert.IsTrue(_structure.IsCellTaken(position));
        }
        
        [Test]
        public void PlaceStructure303AndCheckIsTakenNullObjectFails()
        {
            Vector3 position = new Vector3(3, 0, 3);
            //Act
            GameObject testGameObject = null;
            _structure.PlaceStructureOnTheGrid(testGameObject, position);
            //Assert
            Assert.IsFalse(_structure.IsCellTaken(position));
        }
        
        [Test]
        public void PlaceStructureAndCheckIsIndexOutOfBoundsPositiveFails()
        {
            Vector3 position = new Vector3(303, 0, 303);
            //Act
            //Assert
            Assert.Throws<IndexOutOfRangeException>(() => _structure.IsCellTaken(position));
        }
        
        [Test]
        public void PlaceStructureAndCheckIsIndexOutOfBoundsNegativeFails()
        {
            Vector3 position = new Vector3(-3, 0, -3);
            //Act
            //Assert
            Assert.Throws<IndexOutOfRangeException>(() => _structure.IsCellTaken(position));
        }
        #endregion
    }
}
