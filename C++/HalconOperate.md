## 一、捕获Halcon错误
```c
try
{
  //测试代码
}
catch (HException &except) {
  std::cout << string(except.ErrorMessage()) << "\n";
}
```
