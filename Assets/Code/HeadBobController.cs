using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobController : MonoBehaviour
{
    [SerializeField] private bool _enable = true;

    [SerializeField, Range(0, 0.1f)] private float _amplitude = 0.015f;
    [SerializeField, Range(0, 30)]   private float _frequency = 10.0f;

    [SerializeField] private Transform _camera = null;
    [SerializeField] private Transform _cameraHolder = null;

    private float _toggleSpeed = 3.0f;
    private Vector3 _startPos;
    private PlayerController _controller;

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        _startPos = _camera.localPosition;
    }

    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * _frequency * (_controller.moveSpeed/_controller.initialMoveSpeed)) * _amplitude * (_controller.moveSpeed/_controller.initialMoveSpeed);
        pos.x += Mathf.Cos(Time.time * (_frequency / 2) * (_controller.moveSpeed/_controller.initialMoveSpeed) ) * _amplitude * 2 * (_controller.moveSpeed/_controller.initialMoveSpeed);
        return pos;
    }

    private void PlayMotion(Vector3 motion)
    {
        _camera.localPosition += motion; 
    }

    private void CheckMotion()
    {
        float speed = new Vector3(_controller.GetComponent<Rigidbody>().velocity.x, 0, _controller.GetComponent<Rigidbody>().velocity.z).magnitude;

        if (speed < _toggleSpeed) return;
        if (!_controller.grounded) return;

        PlayMotion(FootStepMotion());
    }

    private void ResetPosition()
    {
        if (_camera.localPosition == _startPos) return;
        _camera.localPosition = Vector3.Lerp(_camera.localPosition, _startPos, 1 * Time.deltaTime);
    }

    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        pos += _cameraHolder.forward * 15.0f;
        return pos;
    }

    void Update()
    {
        if (!_enable) return;

        CheckMotion();
        ResetPosition();
        _camera.LookAt(FocusTarget());
    }
}
