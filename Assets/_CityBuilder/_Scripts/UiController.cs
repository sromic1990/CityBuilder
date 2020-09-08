using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sourav.Utilities.Extensions;

public class UiController : MonoBehaviour
{
    [SerializeField] private Button _buildResidentialAreaButton;
    public Button BuildResidentialAreaButton
    {
        get { return _buildResidentialAreaButton;}
        set
        {
            _buildResidentialAreaButton = value;
        }
    }
    
    [SerializeField] private Button _cancelActionButton;
    public Button CancelActionButton
    {
        get { return _cancelActionButton;}
        set
        {
            _cancelActionButton = value;
        }
    }
    
    [SerializeField] private GameObject _cancelActionPanel;
    public GameObject CancelActionPanel
    {
        get { return _cancelActionPanel;}
        set
        {
            _cancelActionPanel = value;
        }
    }

    [SerializeField] private GameObject _buildingMenuPanel;
    public GameObject BuildingMenuPanel
    {
        get => _buildingMenuPanel;
        set => _buildingMenuPanel = value;
    }
    
    [SerializeField] private Button _openBuildMenuButton;
    public Button OpenBuildMenuButton
    {
        get { return _openBuildMenuButton;}
        set
        {
            _openBuildMenuButton = value;
        }
    }
    
    [SerializeField] private Button _demolishButton;
    public Button DemolishButton
    {
        get { return _demolishButton;}
        set
        {
            _demolishButton = value;
        }
    }
    
    private Action onBuildAreaHandler;
    private Action onCancelActionHandler;
    private Action onDemolishActionHandler;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _cancelActionPanel.Hide();
        _buildingMenuPanel.Hide();
        _buildResidentialAreaButton.onClick.AddListener(OnBuildAreaCallback);
        _cancelActionButton.onClick.AddListener(OnCancelActionCallback);
        _openBuildMenuButton.onClick.AddListener(OnOpenBuildMenu);
        _demolishButton.onClick.AddListener(OnDemolishHandler);
    }

    private void OnDemolishHandler()
    {
        if (onDemolishActionHandler != null)
        {
            onDemolishActionHandler.Invoke();
        }
        _buildingMenuPanel.Hide();
        _cancelActionPanel.Show();
    }

    private void OnOpenBuildMenu()
    {
        _buildingMenuPanel.Show();
    }

    private void OnBuildAreaCallback()
    {
        _cancelActionPanel.Show();
        _buildingMenuPanel.Hide();
        if (onBuildAreaHandler != null)
        {
            onBuildAreaHandler.Invoke();
        }
    }
    private void OnCancelActionCallback()
    {
        _cancelActionPanel.Hide();
        if (onCancelActionHandler != null)
        {
            onCancelActionHandler.Invoke();
        }
    }

    public void AddListener_OnBuildAreaEvent(Action listener)
    {
        onBuildAreaHandler += listener;
    }
    public void RemoveListener_OnBuildAreaEvent(Action listener)
    {
        onBuildAreaHandler -= listener;
    }

    public void AddListener_OnCancelActionEvent(Action listener)
    {
        onCancelActionHandler += listener;
    }
    public void RemoveListener_OnCancelActionEvent(Action listener)
    {
        onCancelActionHandler -= listener;
    }
    
    public void AddListener_OnDemolishActionEvent(Action listener)
    {
        onDemolishActionHandler += listener;
    }
    public void RemoveListener_OnDemolishActionEvent(Action listener)
    {
        onDemolishActionHandler -= listener;
    }
}
