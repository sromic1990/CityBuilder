using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class CellTest
    {
        [Test]
        public void CellSetGameObjectPasses()
        {
            //Arrange
            Cell cell = new Cell();
            //Act
            cell.SetContruction(new GameObject());
            //Assert
            Assert.IsTrue(cell.IsTaken);
        }

        [Test]
        public void CellSetGameObjectNullFails()
        {
            //Arrange
            Cell cell = new Cell();
            //Act
            cell.SetContruction(null);
            //Assert
            Assert.IsFalse(cell.IsTaken);
        }
    }
}
