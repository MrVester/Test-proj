using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;


public class PlayerControllerTutorial:MonoInstaller, IPlayerController
{
    [SerializeField] private float moveDuration=1f;
    private Camera _mainCam;
    private RaycastHit2D _rayHit;
    protected Vector3 _redSquarePos;

    public float Duration
    {
        get { return moveDuration; }
        set { moveDuration = value; }
    }

    void Start()
    {
        _mainCam = Camera.main;
    }

    async void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(IsRedSquare())
            await MovePlayer(_redSquarePos, Duration);

        }
    }

    public bool IsRedSquare()
    {
        _rayHit = Physics2D.GetRayIntersection(_mainCam.ScreenPointToRay(Input.mousePosition));
        if (!_rayHit)
            return false;

        if (!_rayHit.collider.CompareTag("RedSquare"))
            return false;

        _redSquarePos = _rayHit.collider.gameObject.transform.position;
        return true;
    }

    public async Task MovePlayer(Vector2 finalPos, float duration)
    {
        var startingPos = transform.position;
        float timer = 0f;
        while (timer < duration)
        {
            float t = timer / duration;
            transform.position = Vector3.Lerp(startingPos, finalPos, t);
            timer += Time.deltaTime;
            await Task.Yield();
        }
        GameEvents.current.PlayerMoveFinished();
    }
}
