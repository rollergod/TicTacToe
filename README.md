# TicTacToe

тестовое задание от компании "Sense Capital"

## Структура папок

Provide an overview of the directory structure and files, for example:
```bash
├───TicTacToe.Api
│   ├───Controllers
│   ├───Helpers
│   ├───Interfaces
│   ├───Models
│   │   ├───Errors
│   │   │   └───Exceptions
│   │   └───Intefaces
│   ├───Properties
│   └───Services
└───TicTacToe.Console
    ├───Models
    │   └───Intefaces
```
## Запуск приложения

Скачать либо склонировать проект. Запустить .sln файл в папке проекта. В среде разработки запутсить проект(CTRL+F5)

## О приложении

REST api для игры крестики нолики.

Апи имеет 4 endpoint`а

![image](https://user-images.githubusercontent.com/91565374/224567483-a6f7e28a-0768-4d61-a67b-c087b9f93baf.png)

* *get* **/api/game** - возвращает игровую таблицу.
* *post* **/api/game** - принимает два параметра - координата по оси x и коордитана по оси y. Два раза одни и те же координаты указывать нельзя.
* *get* **/api/game/free-coordinates** - возвращает строки с координатами пустых клеток
* *post* **/api/game/new-game** - создает новую игру

## Пример ввода координат

![image](https://user-images.githubusercontent.com/91565374/224567678-6e6df6b4-2278-4b29-ad48-c37cced060ae.png)
