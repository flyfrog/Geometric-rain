using UnityEngine;

public class CalculationMovingLimitService
{
    public MovingLimit GetLimit(Vector2 movingAreaPosition, float widthMovingArea, float widthPlayerShape)
    {
        MovingLimit movingLimit;

        float playerShapeHalfWidth = widthPlayerShape / 2;
        float movingAreaWidthHalf = widthMovingArea / 2;

        movingLimit.left = movingAreaPosition.x - movingAreaWidthHalf + playerShapeHalfWidth;
        movingLimit.right = movingAreaPosition.x + movingAreaWidthHalf - playerShapeHalfWidth;

        return movingLimit;
    }
}