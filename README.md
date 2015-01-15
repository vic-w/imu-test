imu-test
========
此工程利用iPhone内置的加速度、陀螺仪、地磁等传感器估计手机在空间中的姿态。

效果演示：[http://v.youku.com/v_show/id_XODYzMDgzNjY4.html](http://v.youku.com/v_show/id_XODYzMDgzNjY4.html)

1. 运行此程序需要在iPhone上安装Sensor Data Streamer.可在App store中下载.
  * iPhone4S或以上型号才包含地磁传感器
2. 使用时显示器面向南方,使用者面向北方.
3. 将电脑与iPhone连接至同一路由器
4. 编译并运行imu-test工程
5. 打开Sensor Data Streamer, 输入电脑的ip地址,端口号为22222,点击"Send Data to PC"
6. 等待模型稳定,即可进行姿态估计实验
