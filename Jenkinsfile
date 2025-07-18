pipeline {
    agent any

    environment {
        IMAGE_NAME = 'library-management'
        CONTAINER_NAME = 'library-management-container'
        PORT_MAPPING = '8085:80'
    }

    stages {
        stage('Clone Repository') {
            steps {
                git 'https://github.com/Vaishnavi2003-ECE/Library-Management-Sys.git'
            }
        }

        stage('Build') {
            steps {
                dir('LibraryManagement') {
                    bat 'dotnet build ./LibraryManagement/LibraryManagement.csproj'
                }
            }
        }

        stage('Build Docker Image') {
            steps {
                bat "docker build -t %IMAGE_NAME% -f LibraryManagement/Dockerfile LibraryManagement"
            }
        }

        stage('Stop and Remove Old Container') {
            steps {
                bat """
                docker stop %CONTAINER_NAME% || exit 0
                docker rm %CONTAINER_NAME% || exit 0
                """
            }
        }

        stage('Run New Container') {
            steps {
                bat "docker run -d -p %PORT_MAPPING% --name %CONTAINER_NAME% %IMAGE_NAME%"
            }
        }
    }
}
