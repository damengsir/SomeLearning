// Dll1.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "Dll1.h"


Dll_1::Dll_1() {

}


Dll_1::~Dll_1() {

}

void Dll_1::RegisterOutputCallback(OutputCallback callback, void *context)
{
	m_OutputCallback = callback;
    m_pContext = context;
}

void Dll_1::ReadImage() 
{
	const char* ImageFile;
	ImageFile = "D:/20200303153355.jpg";

	IplImage* Src = 0;
	Src = cvLoadImage(ImageFile, -1);//读取彩色图

	if (m_OutputCallback) m_OutputCallback(1,Src ,
		ImageFile, m_pContext);
}