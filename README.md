# Water Carrier Management System

## Quick Guide

Follow these steps to set up the Water Carrier Management System on your local machine.

### 1. Download the Project

- Download the project from the release page.

### 2. Unpack the Project

- Unzip the downloaded file into your desired directory, for example:
.../my_directory_name/WaterCarrierManagementSystem/

### 3. Create the Environment File

- Navigate to the root directory of the project.
- Create a file named `.env` if it does not already exist (either pass the stage 4).

### 4. Configure the Environment File

- Open the `.env` file and fill it with the following configuration. Make sure to set your own credentials if needed:
```plaintext
MYSQL_ROOT_PASSWORD=root123!
MYSQL_HOST=localhost
MYSQL_DATABASE=WaterCarrierDb
MYSQL_USER=super_secret_user
MYSQL_PASSWORD=super_secret_password
MYSQL_TCP_PORT=3306
```

### 5.  Start the Docker Containers  
- Open a terminal and navigate to the root directory where the docker-compose.yml file is located.
- Execute the following command to start the Docker containers:  

`docker-compose up -d`

### 6. Launch the Application  

- After the containers are up and running, launch the application by executing:
  `WaterCarrierManagementSystem.Desktop.exe`
