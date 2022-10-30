using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public LineRenderer _renderer;
    [SerializeField] private EdgeCollider2D _collider;

    private readonly List<Vector2> _points = new List<Vector2>();
    private int i = 0;
    
    void Start()
    {
        _collider.transform.position -= transform.position;

    }

    public void SetPosition(Vector2 pos)
    {
        if (!CanAppend(pos)) return;
        //Debug.Log(_renderer.GetPosition(0));
        //Debug.Log(Vector2.Distance(_renderer.GetPosition(0), _renderer.GetPosition(_renderer.positionCount - 1))   );
        _points.Add(pos);
        _renderer.positionCount++;
        _renderer.SetPosition(_renderer.positionCount-1, pos);

        _collider.points = _points.ToArray();

        if(Vector2.Distance(_renderer.GetPosition(0), _renderer.GetPosition(_renderer.positionCount - 1)) >0.1 
            && Vector2.Distance(_renderer.GetPosition(0), _renderer.GetPosition(_renderer.positionCount - 1)) <0.2)
        {
            i++;
            if (i == 2)
            {
                Debug.Log(" Pasar siguiente nivel");
            }            
        }    
    }

    private bool CanAppend(Vector2 pos)
    {
        if (_renderer.positionCount == 0) return true;
        return Vector2.Distance(_renderer.GetPosition(_renderer.positionCount - 1), pos) > DrawManager.RESOLUTION;
    }
}
