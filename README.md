# LAP Project Group1
## <i>Make a find and retrieve game in Unity using simulated ROS environment then train the bot using reinforcement learning.</i>
# Setup
Make sure you are running ubuntu 18.04.

```sh
sudo apt install ros-melodic-desktop-full
```

```sh
pip3 install mlagents
```

```sh
git clone https://github.com/TinyTrebuchet/Lap-Project.git
```
```sh
cd Ros-Bridge-Setup
```

```sh
source start.bash
```


```sh
cd ..
catkin_make
```
<i>If there is a error in importing Builtins module kindly copy paste the following lines of code in the rosauth properties python file, you may find the path of the same in the detailed error message in terminal.</i>

```py
try:
    from Builtins import str
except ImportErrror:
    from __builtin__ import str
```

You need to install a few python requirements here based on the specific python errors.

```sh
cat Ros-Bridge-Setup/environsetup.sh >> ~/.bashrc
cat Ros-Bridge-Setup/Devel/setup.bash >> ~/.bashrc
source bash
```

Now run the following commands to start the instance of turtlebot.

<b>Note you need to setup the turtulebot3 path in the launch file.</b>
![image](https://user-images.githubusercontent.com/79650452/202985163-6a44109d-78c5-4cf5-9fb8-33557c32c115.png)

```sh
roslaunch file_server publish_description_turtlebot2.launch
```

Add the instance of turtule-bot waffle to Unity.
![image](https://user-images.githubusercontent.com/79650452/202984357-f593b5dd-2d44-40a1-aec9-465a26c44121.png)

![image](https://user-images.githubusercontent.com/79650452/202984402-6ad8ac7e-101d-4f4a-97ad-730542589988.png)

Now stop the above server.


Now fire a instance of turtulebot sim.
```sh
roslaunch $(rospack find rosbridge_server)/launch/rosbridge_websocket.launch

roslaunch $(rospack find turtlebot3_teleop)/launch/turtlebot3_teleop_key.launch
```



Now import the mlagent pack by <b>Window > Package Manager > Import MLAgents.</b>

Now Make a unity game object and add the CS-Assets/Botlearning.cs script to the turtulebot model.

Your TurtuleBot is ready to go!
![image](https://user-images.githubusercontent.com/79650452/202985214-7a8f43fb-07e4-48f6-8c3e-45c458a3d5f5.png)
![image](https://user-images.githubusercontent.com/79650452/202985254-69e8e178-859d-4d7b-9722-1ab71e6bd602.png)

## Dependencies
1. Ubuntu18.04
2. ros-melodic
3. python3.6+, python2.7+, gcc, g++
4. make
5. cmake

## Team Members
1. Ashutosh Purohit
2. Pushkar patel
3. Arkadeep Ghosh
4. Gaurav Guleria
5. Akshat Raj Anand
6. Amit Maindola

