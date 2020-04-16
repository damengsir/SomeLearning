## 1、IplImage* 类型的读取
```
IplImage* src = 0;
src = cvLoadImage("D:/20200303153355.jpg", -1);//读取彩色图
cvReleaseImage(&src);//IplImage*类型使用完毕后，必须手动释放内存
```

## 2、IplImage*类型转换成Mat,并保存
```
IplImage *pImage;
Mat dstImage = cvarrToMat(pImage);
imwrite("D:/yyyy.jpg", dstImage);
```
##2.1 Mat转IplImage*
```
Mat Img=imread("1.jpg");
IplImage* pBinary = &IplImage(Img);//浅拷贝
IplImage *input = cvCloneImage(pBinary);//深拷贝只要再加一次复制数据
```
## 3、IplImage*类型的参数获取
```
src = cvLoadImage("D:/20200303153355.jpg", -1);//读取彩色图
int width = src->width;
int height = src->height;
int widthstep = src->widthstep;
int channel = src->nChannels;
```
## 4、IplImage*：创建一个新的图像的内存块
```
IplImage *pImageDisplay;
int width = 100;
int Height = 200;
int nChannels = 3;
CvSize size = cvSize(Width ,Height);
pImageDisplay = cvCreateImage(size, IPL_DEPTH_8U, nChannels);
```
## 5、改变图像的大小
```
IplImage* src,Dest;

cvResize(src, Dest);//将src的图像大小变成Dest的图像大小，同时将src的图像信息，存储到Dest
```
## 6、内存数据的操作
```
Mat Image;
unsigned char* imageData = Image.data;

//创建一个目标空间
unsigned char* pData = new unsigned char[width,height,pixlByteSize];

//将imageDada复制到PData空间中
memcpy(pData,imageData,width*height*pixByteSize);
```
## 7、在图像中添加文字
```
IplImage* src = 0;
src = cvLoadImage("D:/1.jpg", -1);//读取彩色图

CvFont font;

//初始化字体的结构体：参数(1.初始化的字体，2.字体名称标识符，3.字体宽度，
//4.字体高度，5.字体的斜度，6.字体的粗细度，7.字体笔画的类型)
cvInitFont(&font, CV_FONT_VECTOR0, 4, 4, 0, 6, 8);

//（1.图像指针，2.文字内容，3.打印原点，4.字体属性，5.字体颜色）
cvPutText(src, "I Love You!", cvPoint(100, 150), &font, cvScalar(0, 0, 255, NULL));
cvReleaseImage(&src);
```
## 8、图片镜像
```
IplImage * src = cvLoadImage("D:/Girl.jpg");
cvFlip(src, 0, 1);//水平镜像
cvFlip(src, 0, 0);//垂直镜像
```
## 9、复制图像
```
IplImage * src = cvLoadImage("D:/777.jpg"2 );
IplImage * destImage = cvCloneImage(src);//直接克隆图像，包括图像的ROI信息
cvCopyImage(src,destImage);//只复制图像的ROI
```
## 10、初始化图片，显示图片
```
Iplimage* img = cvCreateImage(cvSize(640,480),IPL_DEPTH_8U,1)
cvZero(img); //让矩阵的值为0；
cvShowImage("img",img);
```
## 11、设置感兴趣区域（截图）
```
IplImage* src = cvLoadImage("a.jpg");
int x = 150;       //矩形左上角x坐标
int y = 150;       //矩形左上角y坐标
int width = 200;   //宽度
int height = 200;  //高度
int add = 150;
cvSetImageROI(src, cvRect(x, y, width, height));
cvResetImageROI(src);
```
