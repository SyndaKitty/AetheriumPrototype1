﻿using UnityEngine;

public static class Util
{
    public const float TwoPi = Mathf.PI * 2;
    public static Vector2 XY(this Vector3 v) => new Vector2(v.x, v.y);

    public static Vector2 Rotate(this Vector2 v, float deg)
    {
        float sin = Mathf.Sin(deg * Mathf.Deg2Rad);
        float cos = Mathf.Cos(deg * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }

    public static float NormalizeAngleDegrees(float degrees)
    {
        while (degrees < 0) degrees += 360;
        return degrees % 360;
    }

    public static float NormalizeAngleRadians(float radians)
    {
        while (radians < 0) radians += TwoPi;
        return radians % TwoPi;
    }

    public static float NormalizeAngleDegrees(float degrees, float min, float max)
    {
        while (degrees < min) degrees += 360;
        while (degrees > max) degrees -= 360;
        return degrees;
    }

    public static float NormalizeAngleRadians(float radians, float min, float max)
    {
        while (radians < min) radians += TwoPi;
        while (radians > max) radians -= TwoPi;
        return radians;
    }

    public static int GetOpposingTeamLayerMask(int teamLayer)
    {
        int allTeams = LayerMask.GetMask("Team1", "Team2", "Team3", "Team4");
        return allTeams - LayerMask.GetMask(LayerMask.LayerToName(teamLayer));
    }

    /// <returns>Whether or not to rotate clockwise</returns>
    public static bool RotateTowardsAngleRadians(float currentAngle, float targetAngle)
    {
        currentAngle = NormalizeAngleRadians(currentAngle);
        targetAngle = NormalizeAngleRadians(targetAngle);

        if (currentAngle > Mathf.PI && (currentAngle + Mathf.PI) % TwoPi > targetAngle)
        {
            return false;
        }
        if (currentAngle < Mathf.PI && currentAngle + Mathf.PI < targetAngle)
        {
            return true;
        }
        if (targetAngle > currentAngle)
        {
            return false;
        }
        return true;
    }

    public static bool RotateTowardsAngleDegrees(float currentAngle, float targetAngle) =>
        RotateTowardsAngleRadians(currentAngle * Mathf.Deg2Rad, targetAngle * Mathf.Deg2Rad);

}