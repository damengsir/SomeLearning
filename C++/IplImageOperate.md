## 一、IplImage* 类型的读取
```
IplImage* src = 0;
src = cvLoadImage("D:/20200303153355.jpg", -1);//读取彩色图
cvReleaseImage(&src);//IplImage*类型使用完毕后，必须手动释放内存
```

## 二、IplImage*类型转换成Mat,并保存
```
IplImage *pImage;
Mat dstImage = cvarrToMat(pImage);
imwrite("D:/yyyy.jpg", dstImage);
```
## 三、IplImage*类型的参数获取
```
src = cvLoadImage("D:/20200303153355.jpg", -1);//读取彩色图
int width = src->width;
int height = src->height;
int widthstep = src->widthstep;
int channel = src->nChannels;
```
## 四、IplImage*图像类型的创建
```
IplImage *pImageDisplay;
int width = 100;
int Height = 200;
int nChannels = 3;
CvSize size = cvSize(Width ,Height);
pImageDisplay = cvCreateImage(size, IPL_DEPTH_8U, nChannels);
```
## 五、改变图像的大小
```
IplImage* src,Dest;

cvResize(src, Dest);//将src的图像大小变成Dest的图像大小
```
