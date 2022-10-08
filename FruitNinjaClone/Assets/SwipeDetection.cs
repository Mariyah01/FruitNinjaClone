using System;
using System.Collections;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
   [SerializeField] private float minimumDistance=.2f;
   [SerializeField] private float maximumDistance=1f;
   [SerializeField, Range(0f,1f)] private float directionThreshold = .9f;
   private InputManager _inputManager;
   private Vector2 startPosition;
   private float startTime;
   private Vector2 endPosition;
   private float endTime;
   [SerializeField] private GameObject trail;
   private Coroutine _coroutine;

   private void Awake()
   {
      _inputManager = InputManager.Instance;
   }

   private void OnEnable()
   {
      _inputManager.OnStartTouch += SwipeStart;
      _inputManager.OnEndTouch += SwipeEnd;
   }

   private void OnDisable()
   {
      _inputManager.OnStartTouch -= SwipeStart;
      _inputManager.OnEndTouch -= SwipeEnd;
   }

   private void SwipeStart(Vector2 position, float time)
   {
      startPosition = position;
      startTime = time;
      trail.SetActive(true);
      trail.transform.position = position;
      _coroutine= StartCoroutine(Trail());
   }

   private IEnumerator Trail()
   {
      while (true)
      {
         trail.transform.position = _inputManager.PrimaryPosition();
         yield return null;
      }
   }

   private void SwipeEnd(Vector2 position, float time)
   {
      trail.SetActive(false);
      StopCoroutine(_coroutine);
      endPosition = position;
      endTime = time;
      DetectSwipe();
   }

   private void DetectSwipe()
   {
      if (Vector3.Distance(startPosition, endPosition) >= minimumDistance &&
          (endTime - startTime) <= maximumDistance)
      {
         Debug.Log("Swipe detected");
         Debug.DrawLine(startPosition,endPosition, Color.red,5f);
         Vector2 direction = endPosition - startPosition;
         SwipeDirection(direction.normalized);
      }
   }

   private void SwipeDirection(Vector2 direction)
   {
      //Up
      if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
      {
         Debug.Log("Swipe up");
      }
      //Down
      else if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
      {
         Debug.Log("Swipe down");
      }
      //Left
      else if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
      {
         Debug.Log("Swipe left");
      }
      //Right
      else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
      {
         Debug.Log("Swipe right");
      }
   }
}
