using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCDialog : MonoBehaviour
{
    public Transform player;

    [SerializeField]
    private TMP_Text _npcText;

    private GameObject _localCanvas;
    private TMP_InputField _playerInputField;
    private Animator _animator;

    private Quaternion _initialRotation;

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

        _initialRotation = transform.rotation;
        Vector3 delta = new Vector3(player.position.x - transform.position.x, 0.0f, player.position.z - transform.position.z);

        transform.rotation = Quaternion.LookRotation(delta);
    }

    public void EndInteraction()
    {
        Debug.Log("Interaction Ended");
        _localCanvas.SetActive(false);

        _animator.SetBool("talking", false);

        transform.rotation = _initialRotation;
    }

    public void GetPlayerInput()
    {
        string text = _playerInputField.text;
        Debug.Log("PLAYER INPUT: " + text);

        // this is where you will hook up ChatGPT API for NPC response
        GenerateNPCResponse(text);

        _playerInputField.text = "";
    }

    private void GenerateNPCResponse(string text)
    {
        _npcText.text = "NEW RESPONSE TO : " + text;
    }
}
