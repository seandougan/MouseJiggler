using System.Windows;

namespace MouseJiggler;

using System.Runtime.InteropServices;

public static class NativeMethods
{
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SetCursorPos(int x, int y);

    public static bool SetCursorPosition(int x, int y)
    {
        return SetCursorPos(x, y);
    }
    public struct POINT
    {
        public int x;
        public int y;

        public static implicit operator Point(POINT p)
        {
            return new Point(p.x,p.y);
        }
    }
    [DllImport("user32.dll")]
    private static extern bool GetCursorPos(out POINT p);

    public static Point GetCursorPosition()
    {
        POINT p;
        GetCursorPos(out p);
        return p;
    }
}
