using NS.GameEventsScripts;
using UnityEngine;
using Zenject;

public class RedSquareController : MonoBehaviour
{
    [SerializeField] private GameObject redSquare;
    private BoxCollider2D spawnArea;
    private int _count=3;
    private GameEvents _gameEvents;


    private void Awake()
    {
      spawnArea = GetComponent<BoxCollider2D>();
    }

    [Inject]
    public void Construct(GameEvents gameEvents) 
    {
        _gameEvents = gameEvents;
    }

    private void Start()
    {
        redSquare.transform.position = GetRandomPos();
        _gameEvents.onPlayerMoveFinished += MoveRedSquare;
    }
    private void OnDestroy()
    {
        _gameEvents.onPlayerMoveFinished -= MoveRedSquare;
    }

    public void MoveRedSquare()
    {
        redSquare.transform.position = GetRandomPos();
        _count--;

        if (_count == 0)
        {
            _gameEvents.EndTutorial();
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
