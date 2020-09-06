using NUnit.Framework;
using Sourav.Utilities.Extensions;
using UnityEngine;

namespace Tests
{
    public class GameObjectExtensionsTest
    {
        [Test]
        public void GameObjectShowPasses()
        {
            //Arrange
            GameObject obj = new GameObject("gObj");
            //Act
            obj.Show();
            //Assert
            Assert.IsTrue(obj.activeSelf);
        }
        
        [Test]
        public void GameObjectHidePasses()
        {
            //Arrange
            GameObject obj = new GameObject("gObj");
            //Act
            obj.Hide();
            //Assert
            Assert.IsFalse(obj.activeSelf);
        }
        
        [Test]
        public void GameObjectNullThrowsException()
        {
            //Arrange
            GameObject obj = null;
            //Act
            obj.Hide();
            //Assert
            Assert.Throws<System.NullReferenceException>(() =>
            {
                var objActiveSelf = obj.activeSelf;
            });
        }
    }
}

