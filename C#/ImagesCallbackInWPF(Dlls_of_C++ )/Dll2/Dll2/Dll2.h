#ifndef _Dll2_
#define _Dll2_

#pragma once
#include <opencv.hpp>
#include "Dll1.h"

typedef void(*OutputCallback)(int port, IplImage *image, const char *imageFileName, void *context);



class Dll_2
{
public:
	Dll_2();
	~Dll_2();
	Dll_1 camera;
	void openCamera();



};
#endif
