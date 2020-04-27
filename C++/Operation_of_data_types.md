## 1、.xml文件数据的读入
当从.xml文件中读入的类型为`const char*`时，需要使用`std::string`类型的变量来接收，不会出错。
## 2、 string 转 CString 或 const char*
```c
string str1 = "ABC";
CString str2;  //const char* str2;
str2 = str1.c_str();
```
## 3、CString 转 string
```c
CString str1;
str1 = "ABC";
string str2 = str1.GetBuffer();
```
## 4、const char* 类型的值不能用于初始化char*
```c
const char * A;
char* B = (char*)A;
```
