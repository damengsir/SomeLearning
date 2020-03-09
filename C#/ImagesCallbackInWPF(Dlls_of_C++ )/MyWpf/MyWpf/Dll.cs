using System;
using System.Runtime.InteropServices;

public delegate void UVSSOutputCallbackDelegate(IntPtr data, int width, int height, int widthStep, int channels, int type); // type: 1: 预览, 2: 出图


class Dll
{
#if DEBUG
    const string DllName = "Dll2.dll";
#else
    const string DllName = "Dll2.dll";
#endif


    [DllImport(DllName, EntryPoint = "StartReadImage", CallingConvention = CallingConvention.Cdecl)]
    public static extern void StartReadImage();

    [DllImport(DllName, EntryPoint = "SetOutputCallback", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetOutputCallback(UVSSOutputCallbackDelegate callback);


}

