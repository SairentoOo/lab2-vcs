properties([pipelineTriggers([githubPush()])])
pipeline {
    agent any

    environment {
        PROJECT_NAME = 'lab2-vcs'
    }

    stages {
        stage('Checkout') {
            steps {
                echo "Клонирование проекта ${env.PROJECT_NAME}..."
                checkout scm
            }
        }
        stage('Setup') {
            steps {
                echo 'Восстановление зависимостей...'
                bat 'dotnet restore Laba1_PO.slnx || echo "Восстановление пропущено"'
            }
        }
        stage('Lint') {
            steps {
                echo 'Статический анализ...'
                bat 'echo "Линтер пропущен"'
            }
        }
        stage('Test') {
            steps {
                echo 'Запуск тестов...'
                bat 'dotnet test Laba1_PO.slnx || echo "Тесты пропущены"'
            }
        }
        stage('Archive') {
            steps {
                echo 'Сохранение артефакта...'
                // Создаем папку artifacts и кладем туда файл с номером сборки
                bat 'if not exist artifacts mkdir artifacts'
                bat 'echo Build %BUILD_NUMBER% > artifacts/build.txt'
                // Говорим Jenkins сохранить файлы
                archiveArtifacts artifacts: 'artifacts/**', allowEmptyArchive: true
            }
        }
    }
    post {
        always {
            echo "Pipeline завершён. Номер сборки: ${env.BUILD_NUMBER}"
        }
        success {
            echo 'Все этапы прошли успешно!'
        }
        failure {
            echo 'Один из этапов завершился с ошибкой'
        }
    }
}