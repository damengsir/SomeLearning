// Dll2.cpp : 定义 DLL 应用程序的导出函数。
//
#include "stdafx.h"
#include "Dll2.h"
#include "UVSS.h"

extern UVSSOutputCallback g_OutputCallback;

void UVSSCameraOutputCallback(int port, IplImage *image, const char *image_file_name, void *context);

void UVSSCameraOutputCallback(int port, IplImage *image, const char *image_file_name, void *context)
{
	IplImage* pImage;
	pImage = cvCloneImage(image);

	(*g_OutputCallback)(pImage->imageData, pImage->width, pImage->height, pImage->widthStep, pImage->nChannels, 2);
	cvReleaseImage(&pImage);
}


Dll_2::Dll_2() {

}


Dll_2::~Dll_2() {

}

void Dll_2::openCamera()
{
	camera.RegisterOutputCallback(UVSSCameraOutputCallback, this);
	camera.ReadImage();
}