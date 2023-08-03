using UnityEngine;

public static class Utils {
    /**
     * Function to draw a box
     */
    public static void DrawBox(Rect r) {
        Vector2 a = new Vector2(r.xMax, r.yMin);
        Vector2 b = new Vector2(r.xMax, r.yMax);
        Vector2 c = new Vector2(r.xMin, r.yMax);
        Vector2 d = new Vector2(r.xMin, r.yMin);

        Gizmos.DrawLine(a, b);
        Gizmos.DrawLine(b, c);
        Gizmos.DrawLine(c, d);
        Gizmos.DrawLine(d, a);
    }
}
