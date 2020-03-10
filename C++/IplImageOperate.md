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
## 六、内存数据的操作
```
Mat Image;
unsigned char* imageData = Image.data;

//创建一个目标空间
unsigned char* pData = new unsigned char[width,height,pixlByteSize];

//将imageDada复制到PData空间中
memcpy(pData,imageData,width*height*pixByteSize);
```
## 七、在图像中添加文字
```
IplImage* src = 0;
src = cvLoadImage("D:/1.jpg", -1);//读取彩色图

CvFont font;

//初始化字体的结构体：参数(1.初始化的字体，2.字体名称标识符，3.字体宽度，
//4.字体高度，5.字体的亵渎，6.字体的粗细度，7.字体笔画的类型)
cvInitFont(&font, CV_FONT_VECTOR0, 4, 4, 0, 6, 8);

//（1.图像指针，2.文字内容，3.打印原点，4.字体属性，5.字体颜色）
cvPutText(src, "I Love You!", cvPoint(100, 150), &font, cvScalar(0, 0, 255, NULL));
cvReleaseImage(&src);
```
