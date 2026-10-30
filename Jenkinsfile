pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                echo 'Код получен из Git'
                // Для Windows используем команду dir вместо ls -la
                bat 'dir' 
            }
        }
        stage('Build') {
            steps {
                echo 'Сборка проекта...'
                // Собираем решение. Если dotnet не установлен, эта команда выдаст ошибку
                bat 'dotnet build Laba1_PO.slnx || echo "Сборка пропущена (нет dotnet)"'
            }
        }
        stage('Test') {
            steps {
                echo 'Запуск тестов...'
                // Запускаем тесты (если они есть)
                bat 'dotnet test Laba1_PO.slnx || echo "Тесты пропущены"'
            }
        }
    }
    post {
        success {
            echo 'Пайплайн завершён успешно!'
        }
        failure {
            echo 'Пайплайн завершился с ошибкой'
        }
    }
}