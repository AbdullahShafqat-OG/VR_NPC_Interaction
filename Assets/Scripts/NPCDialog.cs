using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCDialog : MonoBehaviour
{
    private GameObject _localCanvas;
    private TMP_InputField _playerInputField;
    private Animator _animator;

    private void Start()
    {
        _localCanvas = GetComponentInChildren<Canvas>(true).gameObject;
        _localCanvas.SetActive(false);

        _playerInputField = _localCanvas.GetComponentInChildren<TMP_InputField>(true);
        _animator = GetComponent<Animator>();
    }

    public void BeginInteraction()
    {
        Debug.Log("Interaction Started");
        _localCanvas.SetActive(true);

        _animator.SetBool("talking", true);
    }

    public void EndInteraction()
    {
        Debug.Log("Interaction Ended");
        _localCanvas.SetActive(false);

        _animator.SetBool("talking", false);
    }

    public void GetPlayerInput()
    {
        string text = _playerInputField.text;
        Debug.Log("PLAYER INPUT: " + text);

        _playerInputField.text = "";
    }
}
