#ifndef _UVSS_
#define _UVSS_

#pragma once
#include "Dll2.h"

typedef void(__stdcall *UVSSOutputCallback)(char* buf, int nWidth, int nHeight, int widthStep, int nChannels, int type); // type: 1: 预览, 2: 出图, 3: 比对结果


extern "C"  //实现C++与C的混合编程
{
	__declspec(dllexport) void StartReadImage();
	__declspec(dllexport) void  SetOutputCallback(UVSSOutputCallback callback);

}

class UVSS
{
public:
	UVSS();
	~UVSS();

	Dll_2 Camera;
};
#endif