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
