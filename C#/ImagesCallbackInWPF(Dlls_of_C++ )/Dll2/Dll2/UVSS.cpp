#include "UVSS.h"


UVSS uvss;
UVSSOutputCallback g_OutputCallback = 0;

UVSS::UVSS() 
{

}

UVSS::~UVSS()
{

}


void StartReadImage()
{
	uvss.Camera.openCamera();
}

void SetOutputCallback(UVSSOutputCallback callback)
{
	g_OutputCallback = callback;
}