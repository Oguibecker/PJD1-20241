using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : TransformController
{
    public Transform Target { get; protected set; }

    protected Vector3 TargetPosition;

    public float t = 1f;

    public Vector3 currentVelocity;
    public float smoothTime = 2f;

    protected override void Awake()
    {
        base.Awake();
        Target = PlayerController.Instance.trnsf;
        TargetPosition = tf.position;
    }

    private void LateUpdate()
    {
        //TargetPosition.Set(Target.position.x, Target.position.y, tf.position.z);
        TargetPosition.Set(
            PlayerController.Instance.RigidbodyPosition.x,
            PlayerController.Instance.RigidbodyPosition.y,
            tf.position.z
        );

        //tf.position = Vector3.Lerp(tf.position, TargetPosition, t * Time.deltaTime);
        tf.position = Vector3.SmoothDamp(tf.position, TargetPosition, ref currentVelocity, smoothTime);
    }
}
