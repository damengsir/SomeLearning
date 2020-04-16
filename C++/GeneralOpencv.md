## 一、OpenCV错误的捕获
```
try{
    //有问题的代码
}
catch(cv::Exception& e){
    const char* err_msg = e.what();
    //std::cout << "Exception caught" <<err_msg<<std::endl;//适用于控制台输出
    CString a;
    a+=err_msg;
    AfxMessageBox(a);//适用于MFC
}
```
## 二、VS与OpenCV
* VS与OpenCV的版本号需要对应一致，否则会报错
```
Visual Studio 6 ： vc6
Visual Studio 2003 ： vc7
Visual Studio 2005 ： vc8
Visual Studio 2008 ： vc9
Visual Studio 2010 ： vc10
Visual Studio 2012 ： vc11
Visual Studio 2013 ： vc12
Visual Studio 2015 ： vc14
Visual Studio 2017 ： vc15

```
