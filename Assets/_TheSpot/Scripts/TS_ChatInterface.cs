﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;

public abstract class TS_ChatInterface : NetworkBehaviour {

	public Text m_container;
	internal InputField m_input;
	internal EventSystem m_system;
	private bool m_inputFocused = false;
	private FirstPersonController m_movement;

	private void Start() {
		m_movement = GetComponent<FirstPersonController>();
	}

	private void Update() {
		if (isLocalPlayer) {
			if (Input.GetKeyUp(KeyCode.Return) && !m_inputFocused) {
				m_system.SetSelectedGameObject(m_input.gameObject, null);
				m_inputFocused = true;
				m_movement.enabled = false;
			}
		}
	}

	internal virtual void AddMessage(string message) {
		m_container.text += "\n" + message;
	}

	public void ClearChat() {
		m_input.text = "";
		m_system.SetSelectedGameObject(null, null);
		m_movement.enabled = true;
		StartCoroutine(ResetInputField());
	}

	internal void InitComponents() {
		m_input = GetComponentInChildren<InputField>();
		m_system = GetComponentInChildren<EventSystem>();	
	}

	IEnumerator ResetInputField() {
		yield return new WaitForSeconds(0.5f);
		m_inputFocused = false;
	}

	public abstract new void SendMessage(string input);
}
