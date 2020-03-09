## 一、无法引用dll:
* 1、可能因为直接引用得dll的依赖项未添加到程序文件夹中。
* 2、C#中，添加dll引用得格式代码

```
using System;
using System.Runtime.InteropServices;

public delegate void UVSSOutputCallbackDelegate(IntPtr data, int type); // type: 1: 预览, 2: 出图


class Dll
{
#if DEBUG
    const string DllName = "Dll2d.dll";
#else
    const string DllName = "Dll2.dll";
#endif


    [DllImport(DllName, EntryPoint = "StartReadImage", CallingConvention = CallingConvention.Cdecl)]
    public static extern void StartReadImage();

    [DllImport(DllName, EntryPoint = "SetOutputCallback", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetOutputCallback(UVSSOutputCallbackDelegate callback);

}
```
