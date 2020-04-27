# 1、计算函数运行时间
```c
#include <iostream>
#include <time.h>
int main()
{
   clock_t start, finish;
   double  duration;
   start = clock();

   //some code you need to test

   finish = clock();
   duration = (double)(finish - start) / CLOCKS_PER_SEC;
   printf( "%f seconds\n", duration );
   waitKey();
   return 0;
}

```
