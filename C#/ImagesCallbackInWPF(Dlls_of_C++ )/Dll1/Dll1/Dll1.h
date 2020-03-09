#ifndef _Dll1_
#define _Dll1_



#pragma once
#include <opencv.hpp>

typedef void(*OutputCallback)(int port, IplImage *image, const char *imageFileName, void *context);

#ifdef Dll_1_EXPORTS
class _declspec(dllexport) Dll_1
#else
class _declspec(dllimport) Dll_1
#endif
{
public:
	Dll_1();
	~Dll_1();

	void RegisterOutputCallback(OutputCallback callback, void *context);
	void *m_pContext;
	OutputCallback m_OutputCallback;

	void ReadImage();

};
#endif // Dll1