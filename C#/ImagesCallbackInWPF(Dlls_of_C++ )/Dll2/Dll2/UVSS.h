#ifndef _UVSS_
#define _UVSS_

#pragma once
#include "Dll2.h"

typedef void(__stdcall *UVSSOutputCallback)(char* buf, int nWidth, int nHeight, int widthStep, int nChannels, int type); // type: 1: Ԥ��, 2: ��ͼ, 3: �ȶԽ��


extern "C"  //ʵ��C++��C�Ļ�ϱ��
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