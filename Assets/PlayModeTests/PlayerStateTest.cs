using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    [TestFixture]
    public class PlayerStateTest
    {
        private UiController _uiController;
        private GameManager _gameManagerComponent;
        [SetUp]
        public void Init()
        {
            GameObject gameManagerObject = new GameObject();
            var cameraMovementComponent = gameManagerObject.AddComponent<CameraMovement>();
            gameManagerObject.AddComponent<InputManager>();
            _uiController = gameManagerObject.AddComponent<UiController>();
            GameObject buttonBuildObject = new GameObject();
            GameObject buttonCancel = new GameObject();
            GameObject panelCancel = new GameObject();
            _uiController.CancelActionButton = buttonCancel.AddComponent<Button>();
            var buttonBuildComponent = buttonBuildObject.AddComponent<Button>();
            _uiController.BuildResidentialAreaButton = buttonBuildComponent;
            _uiController.CancelActionPanel = panelCancel;
            _gameManagerComponent = gameManagerObject.AddComponent<GameManager>();
            _gameManagerComponent.CameraMovement = cameraMovementComponent;
            _gameManagerComponent.UiController = _uiController;
        }
        
        [UnityTest]
        public IEnumerator PlayerStatusPlayerBuildingSingleStructureStateTestWithIEnumeratorPasses()
        {
            yield return new WaitForEndOfFrame();//Awake is called
            yield return new WaitForEndOfFrame();//Start is called
            _uiController.BuildResidentialAreaButton.onClick.Invoke();
            yield return new WaitForEndOfFrame();
            Assert.IsTrue(_gameManagerComponent.State is PlayerBuildingSingleStructureState);
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator PlayerStatusPlayerSelectionStateTestWithIEnumeratorPasses()
        {
            yield return new WaitForEndOfFrame();//Awake is called
            yield return new WaitForEndOfFrame();//Start is called
            Assert.IsTrue(_gameManagerComponent.State is PlayerSelectionState);
            yield return null;
        }
    }
}
