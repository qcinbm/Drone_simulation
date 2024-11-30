# Drone Simulation Project

## Overview

This project is a **drone simulation** built using Unity. The simulation integrates Unity with ROS 2 (Robot Operating System) for real-time communication and control. It is designed for research, training, and prototyping in autonomous drone navigation and control systems.

---

## Key Features

- **High-Quality 3D Drone Model:**
  - The simulation uses the Realistic Drone asset, providing a detailed and visually appealing quadcopter model with realistic animations.

- **Unity & ROS 2 Integration:**
  - Seamless communication between Unity and ROS 2 using the ROS TCP Connector.
  - Topics for real-time data exchange:
    - `/camera_image`: Streams the drone's camera feed to ROS 2.
    - `/camera_info`: Sends metadata about the camera, including resolution and field of view.

- **Customizable Environments:**
  - Create and test various terrains and obstacle layouts to simulate real-world scenarios.

- **Realistic Physics:**
  - Includes accurate drone aerodynamics and physics for lifelike simulations.

- **Extendability:**
  - Easily extend the simulation with custom ROS 2 nodes or Unity scripts for advanced functionalities like SLAM, path planning, or object detection.

---

## Requirements

### Software
- **Unity Editor**: Version 2022.3.42f1 or newer.
- **ROS 2**: Compatible with the Foxy, Galactic, or later distributions.
- **ROS-TCP-Connector Package**: For Unity-ROS communication.

### Hardware
- A computer capable of running Unity Editor and ROS 2 simultaneously.
- For real-time camera streaming, ensure a stable local network.

---

## Installation and Setup

### Step 1: Unity Environment
1. Download and install Unity Editor 2022.3.42f1.
2. Clone this repository and open the project in Unity.
3. Import the **Realistic Drone** asset from the Unity Asset Store.

### Step 2: ROS 2 Configuration
1. Set up ROS 2 on your system.
2. Install the required ROS 2 packages (`rosbridge_server`, `cv_bridge`, etc.).
3. Configure the `ROS-TCP-Connector` in Unity with the following settings:
   - **ROS TCP IP**: `192.168.0.xxx`
   - **Port**: `10000`

### Step 3: Topics Configuration
- In Unity, set up the following publishers:
  - `/camera_image`: Stream the drone's camera feed using Unity's Render Texture.
  - `/camera_info`: Publish camera information (e.g., resolution, field of view).
- Ensure ROS 2 nodes are subscribing to these topics.

---

## Usage

1. Launch the Unity simulation and ensure the drone is initialized in the environment.
2. Start your ROS 2 nodes to process camera data or control the drone.
3. Use ROS 2 tools (e.g., `rviz`, `rqt`) to visualize data streams and control signals.

---

## Customization

- **Add Sensors:** Extend the simulation with additional sensors like LiDAR or GPS using Unity components.
- **Dynamic Environments:** Create new environments with Unity's terrain editor for testing in varied conditions.
- **Advanced Control:** Implement custom ROS 2 algorithms for navigation, path planning, or object avoidance.

---

## Troubleshooting

- **No Camera Feed:**
  - Check Unity's ROS-TCP-Connector configuration.
  - Verify the `/camera_image` topic is active in ROS 2.

- **Connectivity Issues:**
  - Confirm the Unity and ROS 2 machines are on the same network.
  - Validate the IP and port settings in Unity.

- **Performance Lag:**
  - Lower the graphics settings in Unity.
  - Optimize ROS 2 nodes for real-time processing.

---

## Future Work

- Integration with SLAM and autonomous navigation.
- Support for multi-drone simulations.
- Real-time simulation of adverse weather conditions.

---

## Credits


- **Unity-ROS Integration:** ROS-TCP-Connector by Unity Robotics Hub.

---
