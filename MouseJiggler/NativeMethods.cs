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
}
