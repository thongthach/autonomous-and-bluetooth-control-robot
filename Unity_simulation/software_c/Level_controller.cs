using JetBrains.Annotations;
using UnityEngine;

public class Level_controller : MonoBehaviour
{
    [SerializeField] GameObject _object;
    public bool currentstate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Toggle();
        }

    }
    public void Toggle()
    {
        currentstate = _object.activeSelf;
        _object.SetActive(!currentstate);
        
    }
}
