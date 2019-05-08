using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{

    /*
    // 旋回速度
    float _rotSpeed = 3.0f;
    /// 移動速度
    float _speed = 3.0f;

    /// 移動角度
    float Direction
    {
        get { return Mathf.Atan2(rigidbody2D.velocity.y, rigidbody2D.velocity.x) * Mathf.Rad2Deg; }
    }

    //rigidbodyの取得
    Rigidbody rb = this.transform.GetComponent<Rigidbody>();

    /// 角度と速度から移動速度を設定する
    void SetVelocity(float direction, float speed)
    {
        var vx = Mathf.Cos(Mathf.Deg2Rad * direction) * speed;
        var vy = Mathf.Sin(Mathf.Deg2Rad * direction) * speed;

        rigidbody2D.velocity = new Vector2(vx, vy);
    }

    /// 更新
    void Update()
    {

        // 画像の角度を移動方向に向ける
        var renderer = GetComponent<SpriteRenderer>();
        renderer.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, Direction));

        // ターゲット座標を取得（マウスの座標に向かって移動する）
        var mousePosition = Input.mousePosition;
        Vector3 next = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 now = transform.position;
        // 目的となる角度を取得する
        var d = next - now;
        var targetAngle = Mathf.Atan2(d.y, d.x) * Mathf.Rad2Deg;
        // 角度差を求める
        var deltaAngle = Mathf.DeltaAngle(Direction, targetAngle);
        var newAngle = Direction;
        if (Mathf.Abs(deltaAngle) < _rotSpeed)
        {
            // 旋回速度を下回る角度差なので何もしない
        }
        else if (deltaAngle > 0)
        {
            // 左回り
            newAngle += _rotSpeed;
        }
        else
        {
            // 右回り
            newAngle -= _rotSpeed;
        }

        // 新しい速度を設定する
        SetVelocity(newAngle, _speed);
    }
    */
}
