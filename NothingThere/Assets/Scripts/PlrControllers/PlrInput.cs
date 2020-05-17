using UnityEngine;

public class PlrInput
{
    private float _horizontal;
    private float _vertical;

    public float Vertical { get => _vertical; set => _vertical = value; }
    public float Horizontal { get => _horizontal; set => _horizontal = value; }

    public void GetInputsAxis()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }
}
