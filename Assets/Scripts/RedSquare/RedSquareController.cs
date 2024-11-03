using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject.Asteroids;

public class RedSquareController : MonoBehaviour
{
    [SerializeField] private GameObject redSquare;
    private BoxCollider2D spawnArea;
    private int _count=3;



    private void Awake()
    {
      spawnArea = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        redSquare.transform.position = GetRandomPos();
        GameEvents.current.onPlayerMoveFinished += MoveRedSquare;
    }
    private void OnDestroy()
    {
        GameEvents.current.onPlayerMoveFinished -= MoveRedSquare;
    }
    void Update()
    {
        
    }
    public void MoveRedSquare()
    {
        redSquare.transform.position = GetRandomPos();
        _count--;

        if (_count == 0)
        {
            GameEvents.current.EndTutorial();
        }
    }
    
    private Vector3 GetRandomPos()
    {
        var xBounds = new Vector2(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
        var yBounds = new Vector2(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
        Vector3 randomPos = new Vector3(Random.Range(xBounds.x,xBounds.y), Random.Range(yBounds.x, yBounds.y), 0f);

        return randomPos;
    }
}
